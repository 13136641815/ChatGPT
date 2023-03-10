﻿using Newtonsoft.Json;
using Npoi.Mapper;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ChatGPT_Admin.Helper
{
    public class NpoiExcelExportHelper
    {
        private static NpoiExcelExportHelper _exportHelper;
        public NpoiExcelExportHelper() { }
        public static NpoiExcelExportHelper _
        {
            get => _exportHelper ?? (_exportHelper = new NpoiExcelExportHelper());
            set => _exportHelper = value;
        }

        /// <summary>
        /// TODO:先创建行，然后在创建对应的列
        /// 创建Excel中指定的行
        /// </summary>
        /// <param name="sheet">Excel工作表对象</param>
        /// <param name="rowNum">创建第几行(从0开始)</param>
        /// <param name="rowHeight">行高</param>
        public HSSFRow CreateRow(ISheet sheet, int rowNum, float rowHeight)
        {
            //创建行
            HSSFRow row = (HSSFRow)sheet.CreateRow(rowNum);
            //设置列头行高
            row.HeightInPoints = rowHeight;
            return row;
        }

        /// <summary>
        /// 创建行内指定的单元格
        /// </summary>
        /// <param name="row">需要创建单元格的行</param>
        /// <param name="cellStyle">单元格样式</param>
        /// <param name="cellNum">创建第几个单元格(从0开始)</param>
        /// <param name="cellValue">给单元格赋值</param>
        /// <returns></returns>
        public HSSFCell CreateCells(HSSFRow row, HSSFCellStyle cellStyle, int cellNum, string cellValue)
        {
            //创建单元格
            HSSFCell cell = (HSSFCell)row.CreateCell(cellNum);
            //将样式绑定到单元格
            cell.CellStyle = cellStyle;
            if (!string.IsNullOrWhiteSpace(cellValue))
            {
                //单元格赋值
                cell.SetCellValue(cellValue);
            }

            return cell;
        }


        /// <summary>
        /// 行内单元格常用样式设置
        /// </summary>
        /// <param name="workbook">Excel文件对象</param>
        /// <param name="hAlignment">水平布局方式</param>
        /// <param name="vAlignment">垂直布局方式</param>
        /// <param name="fontHeightInPoints">字体大小</param>
        /// <param name="isAddBorder">是否需要边框</param>
        /// <param name="boldWeight">字体加粗 (None = 0,Normal = 400，Bold = 700</param>
        /// <param name="fontName">字体（仿宋，楷体，宋体，微软雅黑...与Excel主题字体相对应）</param>
        /// <param name="isAddBorderColor">是否增加边框颜色</param>
        /// <param name="isItalic">是否将文字变为斜体</param>
        /// <param name="isLineFeed">是否自动换行</param>
        /// <param name="isAddCellBackground">是否增加单元格背景颜色</param>
        /// <param name="fillPattern">填充图案样式(FineDots 细点，SolidForeground立体前景，isAddFillPattern=true时存在)</param>
        /// <param name="cellBackgroundColor">单元格背景颜色（当isAddCellBackground=true时存在）</param>
        /// <param name="fontColor">字体颜色</param>
        /// <param name="underlineStyle">下划线样式（无下划线[None],单下划线[Single],双下划线[Double],会计用单下划线[SingleAccounting],会计用双下划线[DoubleAccounting]）</param>
        /// <param name="typeOffset">字体上标下标(普通默认值[None],上标[Sub],下标[Super]),即字体在单元格内的上下偏移量</param>
        /// <param name="isStrikeout">是否显示删除线</param>
        /// <returns></returns>
        public HSSFCellStyle CreateStyle(HSSFWorkbook workbook, HorizontalAlignment hAlignment, VerticalAlignment vAlignment, short fontHeightInPoints, bool isAddBorder, short boldWeight, string fontName = "宋体", bool isAddBorderColor = true, bool isItalic = false, bool isLineFeed = false, bool isAddCellBackground = false, FillPattern fillPattern = FillPattern.NoFill, short cellBackgroundColor = HSSFColor.Yellow.Index, short fontColor = HSSFColor.Black.Index, FontUnderlineType underlineStyle =
            FontUnderlineType.None, FontSuperScript typeOffset = FontSuperScript.None, bool isStrikeout = false)
        {
            HSSFCellStyle cellStyle = (HSSFCellStyle)workbook.CreateCellStyle(); //创建列头单元格实例样式
            cellStyle.Alignment = hAlignment; //水平居中
            cellStyle.VerticalAlignment = vAlignment; //垂直居中
            cellStyle.WrapText = isLineFeed;//自动换行

            //背景颜色，边框颜色，字体颜色都是使用 HSSFColor属性中的对应调色板索引，关于 HSSFColor 颜色索引对照表，详情参考：https://www.cnblogs.com/Brainpan/p/5804167.html

            //TODO：引用了NPOI后可通过ICellStyle 接口的 FillForegroundColor 属性实现 Excel 单元格的背景色设置，FillPattern 为单元格背景色的填充样式

            //TODO:十分注意，要设置单元格背景色必须是FillForegroundColor和FillPattern两个属性同时设置，否则是不会显示背景颜色
            if (isAddCellBackground)
            {
                cellStyle.FillForegroundColor = cellBackgroundColor;//单元格背景颜色
                cellStyle.FillPattern = fillPattern;//填充图案样式(FineDots 细点，SolidForeground立体前景)
            }


            //是否增加边框
            if (isAddBorder)
            {
                //常用的边框样式 None(没有),Thin(细边框，瘦的),Medium(中等),Dashed(虚线),Dotted(星罗棋布的),Thick(厚的),Double(双倍),Hair(头发)[上右下左顺序设置]
                cellStyle.BorderBottom = BorderStyle.Thin;
                cellStyle.BorderRight = BorderStyle.Thin;
                cellStyle.BorderTop = BorderStyle.Thin;
                cellStyle.BorderLeft = BorderStyle.Thin;
            }

            //是否设置边框颜色
            if (isAddBorderColor)
            {
                //边框颜色[上右下左顺序设置]
                cellStyle.TopBorderColor = HSSFColor.Black.Index;//DarkGreen(黑绿色)
                cellStyle.RightBorderColor = HSSFColor.Black.Index;
                cellStyle.BottomBorderColor = HSSFColor.Black.Index;
                cellStyle.LeftBorderColor = HSSFColor.Black.Index;
            }

            /**
             * 设置相关字体样式
             */
            var cellStyleFont = (HSSFFont)workbook.CreateFont(); //创建字体

            //假如字体大小只需要是粗体的话直接使用下面该属性即可
            //cellStyleFont.IsBold = true;

            //cellStyleFont.Boldweight = boldWeight; //字体加粗
            cellStyleFont.FontHeightInPoints = fontHeightInPoints; //字体大小
            cellStyleFont.FontName = fontName;//字体（仿宋，楷体，宋体 ）
            cellStyleFont.Color = fontColor;//设置字体颜色
            cellStyleFont.IsItalic = isItalic;//是否将文字变为斜体
            cellStyleFont.Underline = underlineStyle;//字体下划线
            cellStyleFont.TypeOffset = typeOffset;//字体上标下标
            cellStyleFont.IsStrikeout = isStrikeout;//是否有删除线

            cellStyle.SetFont(cellStyleFont); //将字体绑定到样式
            return cellStyle;
        }
        /// <summary>
        /// 读取Excel
        /// </summary>
        /// <param name="Path">Excel文件地址</param>
        /// <param name="Type">Excel文件后缀</param>
        /// <returns></returns>
        public static string ReadExcel(string Path, string Type)
        {
            if (Type == ".xls")
            {
                return XLS(Path);
            }
            else
            {
                return XLSX(Path);
            }
        }
        public static string StreamRead(Stream s) 
        {
            DataTable dtTable = new DataTable();
            List<string> rowList = new List<string>();
            ISheet sheet;

            HSSFWorkbook xssWorkbook = new HSSFWorkbook(s);
            sheet = xssWorkbook.GetSheetAt(0);
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                {
                    dtTable.Columns.Add(cell.ToString());
                }
            }
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null) continue;
                if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                for (int j = 0; j < cellCount; j++)
                {

                    if (row.GetCell(j) != null)
                    {
                        rowList.Add(row.GetCell(j).ToString());
                        //if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                        //{
                        //    rowList.Add(row.GetCell(j).ToString());
                        //}
                    }
                    else
                    {   //没有的行，用 "" 占位，要不然会出现串列的情况
                        rowList.Add("");
                    }
                }
                if (rowList.Count > 0) dtTable.Rows.Add(rowList.ToArray());
                rowList.Clear();
            }
            return JsonConvert.SerializeObject(dtTable);
        }
        private static string XLS(string Path)
        {
            DataTable dtTable = new DataTable();
            List<string> rowList = new List<string>();
            ISheet sheet;
            using (var stream = new FileStream(Path, FileMode.Open))
            {
                stream.Position = 0;
                HSSFWorkbook xssWorkbook = new HSSFWorkbook(stream);
                sheet = xssWorkbook.GetSheetAt(0);
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                for (int j = 0; j < cellCount; j++)
                {
                    ICell cell = headerRow.GetCell(j);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    {
                        dtTable.Columns.Add(cell.ToString());
                    }
                }
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    for (int j = 0; j < cellCount; j++)
                    {

                        if (row.GetCell(j) != null)
                        {
                            rowList.Add(row.GetCell(j).ToString());
                            //if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                            //{
                            //    rowList.Add(row.GetCell(j).ToString());
                            //}
                        }
                        else
                        {   //没有的行，用 "" 占位，要不然会出现串列的情况
                            rowList.Add("");
                        }
                    }
                    if (rowList.Count > 0) dtTable.Rows.Add(rowList.ToArray());
                    rowList.Clear();
                }
            }
            return JsonConvert.SerializeObject(dtTable);
        }
        private static string XLSX(string Path)
        {
            DataTable dtTable = new DataTable();
            List<string> rowList = new List<string>();
            ISheet sheet;
            using (var stream = new FileStream(Path, FileMode.Open))
            {
                stream.Position = 0;
                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                sheet = xssWorkbook.GetSheetAt(0);
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                for (int j = 0; j < cellCount; j++)
                {
                    ICell cell = headerRow.GetCell(j);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    {
                        dtTable.Columns.Add(cell.ToString());
                    }
                }
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    for (int j = 0; j < cellCount; j++)
                    {

                        if (row.GetCell(j) != null)
                        {
                            rowList.Add(row.GetCell(j).ToString());
                            //if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                            //{
                            //    rowList.Add(row.GetCell(j).ToString());
                            //}
                        }
                        else
                        {   //没有的行，用 "" 占位，要不然会出现串列的情况
                            rowList.Add("");
                        }
                    }
                    if (rowList.Count > 0) dtTable.Rows.Add(rowList.ToArray());
                    rowList.Clear();
                }
            }
            return JsonConvert.SerializeObject(dtTable);
        }
        /// <summary>
        /// List转Excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">数据</param>
        /// <param name="sheetName">表名</param>
        /// <param name="overwrite">true,覆盖单元格，false追加内容(list和创建的excel或excel模板)</param>
        /// <param name="xlsx">true-xlsx，false-xls</param>
        /// <returns>返回文件</returns>
        public static MemoryStream ParseListToExcel<T>(List<T> list, string sheetName = "sheet1", bool overwrite = true, bool xlsx = true) where T : class
        {
            var mapper = new Mapper();
            MemoryStream ms = new MemoryStream();
            mapper.Save<T>(ms, list, sheetName, overwrite, xlsx);
            return ms;
        }
        public static MemoryStream Export_ToExcel(DataTable dt, string strpath, string[] colname)
        {
            //获取导出模板
            string fileName = strpath + "\\Excel\\Export\\Excel.xls";
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            HSSFWorkbook hssfworkbook = new HSSFWorkbook(fs);
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            ICellStyle cellStyle = hssfworkbook.CreateCellStyle();
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < colname.Length; i++)
            {
                string name = colname[i];
                ICell cell = row.CreateCell(i);  //在第一行中创建单元格
                cell.CellStyle = cellStyle;//单元格添加样式
                cell.SetCellValue(name);//循环往第二行的单元格中添加数据   
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow rows = sheet.CreateRow(i + 1);
                    for (int j = 0; j < colname.Length; j++)
                    {
                        string name = colname[j];
                        string columnval = dt.Rows[i][name].ToString();
                        ICell cell = rows.CreateCell(j);  //在第二行中创建单元格
                        cell.CellStyle = cellStyle;//单元格添加样式
                        cell.SetCellValue(columnval);//循环往第二行的单元格中添加数据
                    }
                }

            }
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }
    }
}
