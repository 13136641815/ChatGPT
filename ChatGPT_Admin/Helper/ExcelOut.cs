using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChatGPT_Admin.Helper
{
    public class ExcelOut
    {
        public static async Task<string> ListExcelOut(List<ChatGPT_Model.GPT_CDK> ExcelData, string _WebRootPath)
        {
            //导出的文件路径
            string excelFilePath = "";
            #region 一. Excel表格初始化
            //首先创建Excel文件对象
            var workbook = new HSSFWorkbook();
            //创建工作表，也就是Excel中的sheet，给工作表赋一个名称(Excel底部名称)
            var sheet = workbook.CreateSheet("CDK");
            //默认列宽
            sheet.ForceFormulaRecalculation = true;
            #endregion

            #region 二. Table 表格内容设置

            //TODO:设置顶部大标题样式(参数根据需求自行调整)
            /**
              第一个参数：Excel文件对象 值：HSSFWorkbook
              第二个参数：水平布局方式  值：例=HorizontalAlignment.Center
              第三个参数：垂直布局方式  值：例=VerticalAlignment.Center
              第四个参数：字体大小      值：20
              第五个参数：是否需要边框  值：true/false
              第六个参数：字体加粗 (None = 0,Normal = 400，Bold = 700)
              第七个参数：字体（仿宋，楷体，宋体，微软雅黑...与Excel主题字体相对应）
              第八个参数：是否增加边框颜色              值：true/false
              第九个参数：是否将文字变为斜体            值：true/false
              第十个参数：是否自动换行                  值：true/false
              第十一个参数：是否增加单元格背景颜色      值：true/false
              第十二个参数：填充图案样式(FineDots 细点，SolidForeground立体前景，
                            isAddFillPattern=true时存在)  值：例=FillPattern.SolidForeground
              第十三个参数：单元格背景颜色（当isAddCellBackground=true时存在） 
                            值：例=HSSFColor.Coral.Index
              第十四个参数：字体颜色     值：例=HSSFColor.White.Index
              第十五个参数：下划线样式（无下划线[None],单下划线[Single],双下划线[Double],
                            会计用单下划线[SingleAccounting],会计用双下划线[DoubleAccounting]）
                            值：例=FontUnderlineType.None
              第十六个参数：字体上标下标(普通默认值[None],上标[Sub],下标[Super]),
                            即字体在单元格内的上下偏移量
                            值：例=FontSuperScript.None
              第十七个参数：是否显示删除线  值：true/false
            **/
            var cellStyleFont = NpoiExcelExportHelper._.CreateStyle(workbook, HorizontalAlignment.Center, VerticalAlignment.Center, 16, true, 400, "楷体", true, false, false, true, FillPattern.SolidForeground, HSSFColor.White.Index, HSSFColor.Black.Index,
            FontUnderlineType.None, FontSuperScript.None, false);

            //TODO:创建表格第一行
            /**
              第一个参数：指定的工作表
              第二个参数：表格的第0行
              第三个参数：行高
            **/
            var row = NpoiExcelExportHelper._.CreateRow(sheet, 0, 40);

            //创建该行的第一列，声明变量方便下方引用
            var cell = row.CreateCell(0);
            //合并单元格 例： 第1行到第2行 第3列到第4列围成的矩形区域

            //TODO:关于Excel行列单元格合并问题
            /**
              第一个参数：从第几行开始合并
              第二个参数：到第几行结束合并
              第三个参数：从第几列开始合并
              第四个参数：到第几列结束合并
            **/
            CellRangeAddress region = new CellRangeAddress(0, 0, 0, 17);
            //补全合并后单元格的边框
            ((HSSFSheet)sheet).SetEnclosedBorderOfRegion(region, NPOI.SS.UserModel.BorderStyle.Thin, NPOI.HSSF.Util.HSSFColor.Black.Index);

            sheet.AddMergedRegion(region);


            //合并单元格后，只需对第一个位置赋值即可（TODO:顶部标题）
            string Title = "兑换码批量导出";
            cell.SetCellValue(Title);
            cell.CellStyle = cellStyleFont;


            //二级标题列样式设置
            var headTopStyle = NpoiExcelExportHelper._.CreateStyle(workbook, HorizontalAlignment.Center, VerticalAlignment.Center, 15, true, 400, "楷体", true, false, false, true, FillPattern.SolidForeground, HSSFColor.White.Index, HSSFColor.Black.Index,
            FontUnderlineType.None, FontSuperScript.None, false);

            //表头名称
            var headerName = new[] { "兑换码" };

            //TODO:创建表格第二行
            /**
              第一个参数：指定的工作表
              第二个参数：表格的第1行
              第三个参数：行高
            **/
            row = NpoiExcelExportHelper._.CreateRow(sheet, 1, 30);//第二行
            for (var i = 0; i < headerName.Length; i++)
            {
                sheet.SetColumnWidth(i, 15000);
                cell = NpoiExcelExportHelper._.CreateCells(row, headTopStyle, i, headerName[i]);
            }
            #endregion

            #region 三. 单元格内容信息,数据最终为数据库数据

            //单元格边框样式
            var cellStyle = NpoiExcelExportHelper._.CreateStyle(workbook, HorizontalAlignment.Center, VerticalAlignment.Center, 10, true, 400);
            //当前创建行
            int RowIndex = 2;
            //循环层级是0的_部门
            for (var i = 0; i < ExcelData.Count; i++)
            {

                //sheet.CreateRow(i+2);//在上面表头的基础上创建行
                row = NpoiExcelExportHelper._.CreateRow(sheet, RowIndex, 27);
                //CDK
                string OYear = ExcelData[i].CDK;
                cell = NpoiExcelExportHelper._.CreateCells(row, cellStyle, 0, OYear);
                RowIndex++;
            }
            #endregion

            #region 四. 创建文件夹并将Excel文件保存
            //当天文件夹名称
            string folder = DateTime.Now.ToString("yyyyMMdd");
            //保存文件到静态资源文件夹中（wwwroot）,使用绝对路径
            var uploadPath = _WebRootPath + "/Excel/UpLoad/兑换码导出/" + folder + "/";
            //excel保存文件名
            string excelFileName = "兑换码" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            //创建目录文件夹
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            //Excel的路径及名称
            string excelPath = uploadPath + excelFileName;
            //使用FileStream文件流来写入数据（传入参数为：文件所在路径，对文件的操作方式，对文件内数据的操作）
            var fileStream = new FileStream(excelPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //向Excel文件对象写入文件流，生成Excel文件
            workbook.Write(fileStream);
            //关闭文件流
            fileStream.Close();
            //释放流所占用的资源
            fileStream.Dispose();
            //excel文件保存的相对路径，提供前端下载
            var relativePositioning = "/Excel/UpLoad/兑换码导出/" + folder + "/" + excelFileName;
            excelFilePath = relativePositioning;
            #endregion
            return excelFilePath;
        }
    }
}
