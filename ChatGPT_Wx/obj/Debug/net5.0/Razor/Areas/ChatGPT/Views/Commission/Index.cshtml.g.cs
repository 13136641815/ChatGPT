#pragma checksum "E:\ChatGPT\ChatGPT\ChatGPT_Wx\Areas\ChatGPT\Views\Commission\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49fd23b791b59369a4e0c6b356f2cef0395869ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ChatGPT_Views_Commission_Index), @"mvc.1.0.view", @"/Areas/ChatGPT/Views/Commission/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49fd23b791b59369a4e0c6b356f2cef0395869ef", @"/Areas/ChatGPT/Views/Commission/Index.cshtml")]
    #nullable restore
    public class Areas_ChatGPT_Views_Commission_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\ChatGPT\ChatGPT\ChatGPT_Wx\Areas\ChatGPT\Views\Commission\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49fd23b791b59369a4e0c6b356f2cef0395869ef3005", async() => {
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <meta name=""viewport""
          content=""width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"" />
    <link rel=""stylesheet"" href=""/lib/vant/css/index.css"" />
    <link href=""/ChatGPT_Wx/Style.css"" rel=""stylesheet"" />
    <title>");
#nullable restore
#line 12 "E:\ChatGPT\ChatGPT\ChatGPT_Wx\Areas\ChatGPT\Views\Commission\Index.cshtml"
      Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>
    <style>
        html {
            background-color: #e0f0ff;
        }

        .CTitle {
            font-size: 14px;
            color: #727272;
        }

        .CMain {
            font-size: 18px;
            color: #1989fa;
            font-weight: 500;
        }

        .Content {
            color: #000000;
        }

        .ContentN {
            color: #1989fa;
        }
        .flontBtn {
            position: fixed;
            background-color: #1989fa;
            width: 50px;
            height: 50px;
            z-index: 2;
            color: #ffffff;
            border-radius: 38px;
            line-height: 16px;
            right: 10px;
            top: 97px;
            font-size: 14px;
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49fd23b791b59369a4e0c6b356f2cef0395869ef5353", async() => {
                WriteLiteral("\r\n    <div id=\"app\" v-cloak>\r\n        <div class=\"flontBtn\"><div style=\"width: 29px; margin: 0 auto; margin-top: 8px;\" ");
                WriteLiteral("@click=\"TX\">佣金提现</div></div>\r\n        <van-nav-bar title=\"分佣详情\"\r\n                     left-text=\"返回\"\r\n                     right-text=\"推广对象\"\r\n                     left-arrow\r\n                     ");
                WriteLiteral("@click-left=\"onClickLeft\"\r\n                     ");
                WriteLiteral("@click-right=\"onClickRight\"></van-nav-bar>\r\n        <van-dropdown-menu>\r\n            <van-dropdown-item v-model=\"CheckState\" :options=\"option\" ");
                WriteLiteral("@change=\"dropdown\"></van-dropdown-item>\r\n            <van-dropdown-item title=\"时间\" ref=\"item\">\r\n                <van-cell center");
                BeginWriteAttribute("title", " title=\"", 1874, "\"", 1882, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                    <template #right-icon>\r\n                        <van-cell title=\"选择日期区间\" :value=\"date\" ");
                WriteLiteral(@"@click=""show = true""></van-cell>
                    </template>
                </van-cell>
            </van-dropdown-item>
        </van-dropdown-menu>
        <van-cell-group inset :title=""`合计金额：${Page.JE}元`"">
            <van-collapse v-model=""activeName"" accordion>
                <van-collapse-item :name=""Item.ID"" v-for=""(Item,Index) in List"" :key=""Index"">
                    <template #title>
                        <div>
                            <span class=""CTitle"">分佣：</span>
                            <span class=""CMain"">{{Item.Commission}}</span>
                            <span class=""CTitle"">元</span>
                            <van-tag color=""#bfbfbf"" text-color=""#ffffff"" v-if=""Item.CheckState==0"">未提现</van-tag>
                            <van-tag type=""primary"" v-else-if=""Item.CheckState==2"">提现中</van-tag>
                            <van-tag type=""success"" v-else>已提现</van-tag>
                        </div>
                    </template>
                    <van-row>
 ");
                WriteLiteral(@"                       <van-col span=""12"">推广对象</van-col>
                        <van-col span=""12"" class=""Content"">{{Item.Buy_NikeName}}</van-col>
                    </van-row>
                    <van-row>
                        <van-col span=""12"">支付时间</van-col>
                        <van-col span=""12"" class=""Content"">{{Item.BackStamp}}</van-col>
                    </van-row>
                    <van-row>
                        <van-col span=""12"">支付商品</van-col>
                        <van-col span=""12"" class=""Content"">{{Item.CommodityName}}</van-col>
                    </van-row>
                    <van-row>
                        <van-col span=""12"">支付原价</van-col>
                        <van-col span=""12"" class=""Content"">{{Item.OrderAmountYuan}}元</van-col>
                    </van-row>
                    <van-row>
                        <van-col span=""12"">分佣比例</van-col>
                        <van-col span=""12"" class=""Content"">{{Item.ShareCommission}}</van-col>
             ");
                WriteLiteral(@"       </van-row>
                    <van-row>
                        <van-col span=""12"">实际分佣</van-col>
                        <van-col span=""12"" class=""ContentN"">{{Item.Commission}}元</van-col>
                    </van-row>
                </van-collapse-item>
            </van-collapse>
        </van-cell-group>
        <div style=""height:40px;""></div>
        <van-pagination style=""position:fixed;bottom:0;width:100%;""
                        v-model=""Page.PageNum""
                        :total-items=""Page.Total""
                        :show-page-size=""3""
                        :items-per-page=""10""
                        force-ellipses></van-pagination>
        <van-calendar v-model=""show"" type=""range"" ");
                WriteLiteral(@"@confirm=""onConfirm"" :min-date=""minDate""></van-calendar>
        <van-popup v-model=""PopupShow"" position=""bottom"" :style=""{ height: '90%' }"">
            <van-cell v-for=""(Item,Index) in UserList"" :key=""Index"">
                <!-- 使用 title 插槽来自定义标题 -->
                <template #title>
                    <span class=""custom-title"">
                        <van-image round
                                   width=""64px""
                                   height=""64px""
                                   :src=""Item.WxHeadUrl""></van-image>
                    </span>
                </template>
                <template #right-icon>
                    <div style=""line-height:71px;"">{{Item.NikeName}}</div>
                </template>
            </van-cell>
        </van-popup>
    </div>
    <script src=""/lib/vue/vue.js""></script>
    <script src=""/lib/vant/js/vant.js""></script>
    <script src=""/lib/axios/axios.js""></script>
    <script>
        // 在 #app 标签下渲染一个按钮组件
        new Vue({
");
                WriteLiteral(@"            el: '#app',
            data: {
                CheckState: 0,
                TimeStart: '',
                TimeEnd: '',
                option: [
                    { text: '未提现', value: 0 },
                    { text: '提现中', value: 2 },
                    { text: '已提现', value: 1 }
                ],
                minDate: new Date(2023, 1, 1),
                date: '',
                activeName: '',
                List: [],
                UserList: [],
                Page: {
                    PageNum: 1,
                    PageSize: 7,
                    Total: 500,
                    JE: 0.00,
                },
                show: false,
                PopupShow: false
            },
            methods: {
                TX() {
                    axios({
                        method: 'get',
                        url: '/ChatGPT/Commission/ChekedIsOk',
                        headers: {
                            'Content-Type': 'applicatio");
                WriteLiteral(@"n/json; charset=UTF-8'
                        },
                    }).then(res => {
                        //满足提现要求，询问是否要提现
                        vant.Dialog.confirm({
                            title: '确认提现吗',
                            message: `提现${res.DATACOUNT}笔，${res.SUM}元`,
                        }).then(() => {
                            axios({
                                method: 'post',
                                url: '/ChatGPT/Commission/Account',
                                headers: {
                                    'Content-Type': 'application/json; charset=UTF-8'
                                },
                            }).then(res => {
                                vant.Notify({ type: 'success', message: '提现申请成功，请等待管理员处理！', duration: 5000 });
                                this.GetList();
                            }).catch(err => {

                            })
                        }).catch(() => {
                            // on ");
                WriteLiteral(@"cancel
                        });
                    }).catch(err => {
                        //不允许提现
                        vant.Dialog.alert({
                            title: '消息',
                            message: err,
                        }).then(() => {
                            // on close
                        });
                    })
                },
                dropdown() {
                    this.GetList();
                },
                onClickLeft() {
                    history.back();
                },
                onClickRight() {
                    this.PopupShow = true;
                },
                formatDate(date) {
                    return `${date.getFullYear()}/${date.getMonth() + 1}/${date.getDate()}`;
                },
                onConfirm(date) {
                    const [start, end] = date;
                    this.show = false;
                    this.TimeStart = this.formatDate(start);
                    ");
                WriteLiteral(@"this.TimeEnd = this.formatDate(end);
                    this.date = `${this.TimeStart} - ${this.TimeEnd}`;
                    this.GetList();
                },
                GetList() {
                    axios({
                        method: 'get',
                        url: '/ChatGPT/Commission/GetListPage',
                        params: {
                            TimeStart: this.TimeStart,
                            TimeEnd: this.TimeEnd,
                            CheckState: this.CheckState,
                            PageNum: this.Page.PageNum,
                            PageSize: this.Page.PageSize
                        },
                        headers: {
                            'Content-Type': 'application/json; charset=UTF-8'
                        },
                    }).then(res => {
                        this.List = res.DATA;
                        this.Page.Total = res.DATACOUNT;
                        this.Page.JE = res.DATASUM
            ");
                WriteLiteral(@"        }).catch(err => {

                    })
                },
                GetUserList() {
                    axios({
                        method: 'get',
                        url: '/ChatGPT/Commission/GetUserListPage',
                        headers: {
                            'Content-Type': 'application/json; charset=UTF-8'
                        },
                    }).then(res => {
                        this.UserList = res;
                    }).catch(err => {

                    })
                }
            },
            created() {
                this.GetList();
                this.GetUserList();
            },
            mounted() {

            }
        })
    </script>
");
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
            WriteLiteral("\r\n</html>");
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
