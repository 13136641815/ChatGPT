#pragma checksum "E:\ChatGPT\ChatGPT\ChatGPT_Admin\Areas\ChatGPT\Views\Bill\BillList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "773f268165facb8b82b61e9118d03a2fe5138367"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ChatGPT_Views_Bill_BillList), @"mvc.1.0.view", @"/Areas/ChatGPT/Views/Bill/BillList.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"773f268165facb8b82b61e9118d03a2fe5138367", @"/Areas/ChatGPT/Views/Bill/BillList.cshtml")]
    #nullable restore
    public class Areas_ChatGPT_Views_Bill_BillList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\ChatGPT\ChatGPT\ChatGPT_Admin\Areas\ChatGPT\Views\Bill\BillList.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "773f268165facb8b82b61e9118d03a2fe51383673001", async() => {
                WriteLiteral(@"
    <meta name=""viewport"" content=""width=device-width"" />
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- Element CSS -->
    <link rel=""stylesheet"" href=""/lib/Element/css/index.css"">
    <!-- 全局通用样式 -->
    <link rel=""stylesheet"" href=""/lib/css/style.css"" />
    <title></title>
    <style>
        .Tips {
            margin-top:20px;
        }
            .Tips span {
                color: #0094ff;
                font-weight: 900;
                margin-left: 10px;
                margin-right: 10px;
            }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "773f268165facb8b82b61e9118d03a2fe51383674601", async() => {
                WriteLiteral(@"
    <div id=""app"" v-cloak>
        <el-container>
            <el-header height=""40"">
                <div class=""SelectDiv"">
                    <div class=""InputContainer"">
                        <el-input v-model=""model.OrderNumber"" placeholder=""订单号"" clearable></el-input>
                    </div>
                    <div class=""DatePickContainer"">
                        <el-date-picker v-model=""model.Times""
                                        type=""daterange""
                                        align=""right""
                                        unlink-panels
                                        range-separator=""至""
                                        start-placeholder=""开始日期""
                                        end-placeholder=""结束日期""
                                        :picker-options=""pickerOptions""
                                        style=""width:410px;"">
                        </el-date-picker>
                    </div>
                    <div clas");
                WriteLiteral(@"s=""SelectContainerLager"">
                        <el-select v-model=""model.Channel"" placeholder=""支付方式"" style=""width:100%;"" clearable>
                            <el-option label=""微信H5"" value=""微信H5""></el-option>
                            <el-option label=""微信小程序"" value=""微信小程序""></el-option>
                            <el-option label=""抖音小程序"" value=""抖音小程序""></el-option>
                        </el-select>
                    </div>
                    <div class=""ButtonContainer"">
                        <el-button type=""primary"" icon=""el-icon-search"" ");
                WriteLiteral(@"@click=""Select"">搜索</el-button>
                    </div>
                    <div class=""Tips"">共有<span >{{SUM.DATACOUNT}}</span>笔交易，共计收款<span>{{Format(SUM.DATASUM)}}</span>元</div>
                </div>
            </el-header>
            <el-main>
                <el-table :data=""tableData""
                          size=""mini""
                          border
                          max-height=""500""
                          row-key=""ID""
                          style=""width: 100%;min-height:487px;"">
                    <el-table-column prop=""ID""
                                     label=""ID""
                                     width=""50""
                                     align=""center"">
                    </el-table-column>
                    <el-table-column prop=""Stamp""
                                     label=""入账时间""
                                     width=""200"">
                    </el-table-column>
                    <el-table-column prop=""Channel""
             ");
                WriteLiteral(@"                        label=""支付方式""
                                     width=""130"">
                    </el-table-column>
                    <el-table-column prop=""OrderNumber""
                                     label=""订单号"">
                    </el-table-column>
                    <el-table-column prop=""NikeName""
                                     label=""支付人""
                                      width=""200"">
                    </el-table-column>
                    <el-table-column prop=""CommodityName""
                                     label=""套餐名称""
                                     width=""120"">
                    </el-table-column>
                    <el-table-column prop=""Duration""
                                     label=""套餐时长（月）""
                                     width=""130"">
                    </el-table-column>
                    <el-table-column prop=""OrderAmountYuan""
                                     label=""支付金额（元）""
                                    ");
                WriteLiteral(@" width=""130"">
                        <template slot-scope=""scope"">
                            {{Format(scope.row.OrderAmountYuan)}}
                        </template>
                    </el-table-column>
                    <el-table-column prop=""OrderAmountFen""
                                     label=""支付金额（分）""
                                     width=""130"">
                    </el-table-column>
");
                WriteLiteral("                </el-table>\r\n            </el-main>\r\n            <el-footer>\r\n                <el-pagination ");
                WriteLiteral("@size-change=\"handleSizeChange\"\r\n                               ");
                WriteLiteral(@"@current-change=""handleCurrentChange""
                               :current-page=""PageParams.PageNum""
                               :page-sizes=""PageParams.PageSizeList""
                               :page-size=""PageParams.PageSize""
                               layout=""total, sizes, prev, pager, next, jumper""
                               :total=""PageParams.Total""
                               style=""width:99%;"">
                </el-pagination>
            </el-footer>
            <el-dialog :title=""Dialog.Title"" :visible.sync=""Dialog.Show"">

            </el-dialog>
        </el-container>
    </div>
    <script src=""/lib/Vue/vue.js""></script>
    <script src=""/lib/Element/js/index.js""></script>
    <script src=""/lib/axios/axios.js""></script>
    <script src=""/lib/Scripts/admin.js""></script>
    <script>
        new Vue({
            el: '#app',
            data: function () {
                return {
                    pickerOptions: {
                        shortcuts: [{");
                WriteLiteral(@"
                            text: '最近一周',
                            onClick(picker) {
                                const end = new Date();
                                const start = new Date();
                                start.setTime(start.getTime() - 3600 * 1000 * 24 * 7);
                                picker.$emit('pick', [start, end]);
                            }
                        }, {
                            text: '最近一个月',
                            onClick(picker) {
                                const end = new Date();
                                const start = new Date();
                                start.setTime(start.getTime() - 3600 * 1000 * 24 * 30);
                                picker.$emit('pick', [start, end]);
                            }
                        }, {
                            text: '最近三个月',
                            onClick(picker) {
                                const end = new Date();
                         ");
                WriteLiteral(@"       const start = new Date();
                                start.setTime(start.getTime() - 3600 * 1000 * 24 * 90);
                                picker.$emit('pick', [start, end]);
                            }
                        }]
                    },
                    SUM: {
                        DATACOUNT: 0,
                        DATASUM: 0.00,
                    },
                    tableData: [],
                    PageParams: {
                        PageSizeList: window.PageSizeList,
                        PageNum: 1,
                        PageSize: 10,
                        Total: 0
                    },
                    model: {
                        Channel: '',
                        Times: [this.SRecentTime(), this.ERecentTime()],//时间,
                        OrderNumber: ''
                    },
                    Dialog: {
                        Title: '',
                        Show: false,
                    },
            ");
                WriteLiteral(@"        labelwidth: '35%',
                    thisRow: {},
                };
            },
            methods: {
                //千位符函数
                Format(num) {
                    if (num) {
                        const Number = parseFloat(num).toFixed(2);
                        return Number.replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
                    }
                    else {
                        return '0.00';
                    }
                },
                //时间转换
                DateConvert(TimeStamp) {
                    var Time = new Date(TimeStamp);
                    var Year = Time.getFullYear();
                    var Month = Time.getMonth() + 1;
                    var Day = Time.getDate();
                    return Year + '-' + this.Supplement(Month) + '-' + this.Supplement(Day);
                },
                //时间零补位
                Supplement(TimeVal) {
                    return parseInt(TimeVal) < 10 ? '0' + TimeVal : TimeVal
       ");
                WriteLiteral(@"         },
                //最近一个月(开始时间)
                SRecentTime() {
                    const start = new Date();
                    start.setTime(start.getTime() - 3600 * 1000 * 24 * 30);
                    return start;
                },
                //最近一个月(结束时间)
                ERecentTime() {
                    const end = new Date();
                    return end;
                },
                Select() {
                    this.PageParams.pageNum = 1;
                    this.GetListPage();
                },
                GetListPage() {
                    const that = this;
                    //开始时间
                    let TimeStart = '';
                    let TimeEnd = '';
                    if (that.model.Times.length > 0) {
                        TimeStart = that.DateConvert(that.model.Times[0]);
                        TimeEnd = that.DateConvert(that.model.Times[1]);
                    }
                    axios({
                        meth");
                WriteLiteral(@"od: 'get',
                        url: '/ChatGPT/Bill/GetListPage',
                        params: {
                            Channel: that.model.Channel,
                            OrderNumber: that.model.OrderNumber,
                            TimeStart: TimeStart,
                            TimeEnd: TimeEnd,
                            PageNum: that.PageParams.PageNum,
                            PageSize: that.PageParams.PageSize,
                        },
                        headers: {
                            'Content-Type': 'application/json; charset=UTF-8'
                        },
                    }).then(function (res) {
                        that.SUM.DATACOUNT = res.DATACOUNT;
                        that.SUM.DATASUM = res.DATASUM;
                        that.tableData = res.DATA;
                        that.PageParams.Total = res.DATACOUNT;
                    }).catch(function (err) {
                        that.$message.error(err);
                   ");
                WriteLiteral(@" });
                    this.tableData;
                },
                handleSizeChange(pageSize) {
                    //当前页数
                    this.PageParams.PageNum = 1;
                    //当前页最大值
                    this.PageParams.PageSize = pageSize;
                    this.GetListPage();
                },
                handleCurrentChange(pageNum) {
                    //当前页数
                    this.PageParams.PageNum = pageNum;
                    this.GetListPage();
                },
                CheckTime(Time) {
                    let DataTime = new Date(Time);
                    let TimeNow = new Date();
                    if (TimeNow > DataTime) {
                        return true;
                    } else {
                        return false;
                    }
                }
            },
            created: function () {
                this.GetListPage();
            },
            mounted: function () {

            }
       ");
                WriteLiteral(" })\r\n    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
