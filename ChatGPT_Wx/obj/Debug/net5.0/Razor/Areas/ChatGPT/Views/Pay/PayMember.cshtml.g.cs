#pragma checksum "E:\ChatGPT\ChatGPT\ChatGPT_Wx\Areas\ChatGPT\Views\Pay\PayMember.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f12b50fd09675aac33068b557aa42665e55c09ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ChatGPT_Views_Pay_PayMember), @"mvc.1.0.view", @"/Areas/ChatGPT/Views/Pay/PayMember.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f12b50fd09675aac33068b557aa42665e55c09ac", @"/Areas/ChatGPT/Views/Pay/PayMember.cshtml")]
    #nullable restore
    public class Areas_ChatGPT_Views_Pay_PayMember : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\ChatGPT\ChatGPT\ChatGPT_Wx\Areas\ChatGPT\Views\Pay\PayMember.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f12b50fd09675aac33068b557aa42665e55c09ac2991", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no"" />
    <link rel=""stylesheet"" type=""text/css"" href=""/ChatGPT_Wx/statics/css/style.css"" />
    <link href=""/ChatGPT_Wx/Style.css"" rel=""stylesheet"" />
    <script src=""/ChatGPT_Wx/statics/js/flexible.js"" type=""text/javascript"" charset=""utf-8""></script>
    <script src=""/ChatGPT_Wx/statics/js/zepto.min.js"" type=""text/javascript"" charset=""utf-8""></script>
    <style>
        [v-cloak] {
            display: none;
        }
    </style>
    <title>");
#nullable restore
#line 19 "E:\ChatGPT\ChatGPT\ChatGPT_Wx\Areas\ChatGPT\Views\Pay\PayMember.cshtml"
      Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n");
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f12b50fd09675aac33068b557aa42665e55c09ac4821", async() => {
                WriteLiteral("\r\n    <div id=\"app\" v-cloak>\r\n        <div class=\"top\">\r\n            <!--标题-->\r\n            <div class=\"title\">\r\n                <h3>会员中心</h3>\r\n                <span class=\"more\" ");
                WriteLiteral("@click=\"more\"></span>\r\n                <div class=\"more-box\" v-show=\"showMore\">\r\n                    <a ");
                WriteLiteral(@"@click=""onClickLeft"">返回</a>
                </div>
            </div>
            <!--类型-->
            <div class=""type"">
                <ul>
                    <li class=""active"">精选</li>
                </ul>
            </div>
            <!--状态-->
            <div class=""status"">
                <span>{{UserInfo.IsShowTime?'可续费':'未开通'}}</span>
                <p>*开通会员无限畅聊</p>
            </div>
        </div>
        <!--精选会员卡列表-->
        <div class=""card-list active"">
            <div class=""cate"">
                <p class=""active""><i></i>超级会员</p>
            </div>
            <div class=""list"">
                <ul class=""active"">
                    <van-radio-group v-model=""radio"" style=""display: flex;"">
                        <li :class=""radio==Item.ID?'active':''"" v-for=""(Item,Index) in CommodityList"" :key=""Index"">
                            <van-radio :name=""Item.ID"" shape=""square"" >
                                <div class=""title"">{{Item.CommodityName}}</div>
     ");
                WriteLiteral(@"                           <div class=""desc"">
                                    <p class=""yh"" v-show=""Item.Explain"">{{Item.Explain}}</p>
                                    <p class=""money""><i>¥</i><span>{{(Item.CommodityPresentPrice/100).toFixed(2)}}</span></p>
                                    <p class=""old"">原价¥{{(Item.CommodityOriginalPrice/100).toFixed(2)}}</p>
                                </div>
                            </van-radio>
                        </li>
                    </van-radio-group>
                </ul>

            </div>
        </div>
        <!--特权-->
        <div class=""tequan"">
            <ul>
                <li>
                    <img src=""/ChatGPT_Wx/statics/images/icon-meilizhi.png"" />
                    <p>服务</p>
                    <span>一对一客服</span>
                </li>
                <li>
                    <img src=""/ChatGPT_Wx/statics/images/icon-huiyuanjia.png"" />
                    <p>接口</p>
                    <span>独享接口对话</sp");
                WriteLiteral(@"an>
                </li>
                <li>
                    <img src=""/ChatGPT_Wx/statics/images/icon-huiyuanri.png"" />
                    <p>畅聊</p>
                    <span>享无任何限时</span>
                </li>
                <li>
                    <img src=""/ChatGPT_Wx/statics/images/icon-shengri.png"" />
                    <p>极速</p>
                    <span>无等待回复</span>
                </li>
            </ul>
        </div>
        <!--开通会员-->
        <div class=""submit"">
            <van-button type=""success"" ");
                WriteLiteral(@"@click=""Pay"" :disabled=""ButtonEnable"">立即{{UserInfo.YN_VIP==1&&UserInfo.BeOverdue_VIP>new Date().toLocaleString()?'续费':'开通'}}</van-button>
        </div>
        <p class=""tip"" style=""font-size: 14px;text-align: center; color: #b7b7b7;"">会员服务为虚拟商品，支付成功后不支持退款</p>
    </div>
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
            WriteLiteral(@"

</html>
<script src=""/lib/vue/vue.js""></script>
<script src=""/lib/vant/js/vant.js""></script>
<script src=""/lib/axios/axios.js""></script>
<script>
    new Vue({
        el: '#app',
        data: {
            radio: 1,
            UserInfo: {},
            CommodityList: [],
            ButtonEnable: false,
            showMore: false,
        },
        methods: {
            more() {
                this.showMore = !this.showMore;
            },
            onClickLeft() {
                history.back();
            },
            Pay() {
                const that = this;
                that.ButtonEnable = true;
                axios({
                    method: 'post',
                    url: '/ChatGPT/Pay/DownOrder',
                    data: {
                        ComID: this.radio
                    },
                    headers: {
                        'Content-Type': 'application/json; charset=UTF-8',
                        'No-Loding': true
            ");
            WriteLiteral(@"        },
                }).then(res => {
                    //模拟支付成功
                    //vant.Toast.loading({
                    //    message: '支付模拟中...',
                    //    forbidClick: true,
                    //    overlay: true,
                    //    forbidClick: true,
                    //    duration: 0
                    //});
                    //axios({
                    //    method: 'get',
                    //    url: '/ChatGPT/PayBack/TestBack',
                    //    params: {
                    //        No: res.OrderNo,
                    //        Openid: that.UserInfo.WxOpenID
                    //    },
                    //    headers: {
                    //        'Content-Type': 'application/json; charset=UTF-8',
                    //        'No-Loding': true
                    //    },
                    //}).then(res => {
                    //    setTimeout(() => {
                    //        vant.Toast.success('支付成功');
 ");
            WriteLiteral(@"                   //        setTimeout(() => {
                    //            vant.Toast.clear();
                    //            history.back();
                    //        }, 2000)
                    //    }, 3000)
                    //}).catch(err => {
                    //    vant.Toast.fail('模拟失败，请重试');
                    //    setTimeout(() => {
                    //        vant.Toast.clear();
                    //    }, 2000)
                    //})
                    //订单校验成功，唤起支付
                    const PayData = res.PayData;
                    const PayConfig = res.PayConfig;
                    axios({
                        method: 'post',
                        url: `/WeChatHome/Pay`,
                        data: {
                            PayData: PayData,
                            PayConfig: PayConfig
                        },
                        headers: {
                            'Content-Type': 'application/json; charset=UTF-8'
      ");
            WriteLiteral(@"                  },
                    }).then(function (res) {
                        const PayJson = JSON.parse(res);
                        WeixinJSBridge.invoke(
                            'getBrandWCPayRequest', PayJson,//josn串
                            function (res) {
                                if (res.err_msg == ""get_brand_wcpay_request:ok"") {
                                    //支付成功
                                    history.back();
                                } else if (res.err_msg == ""get_brand_wcpay_request:cancel"") {
                                    vant.Notify({ type: 'primary', message: '支付取消' });
                                    that.ButtonEnable = false;
                                } else {
                                    that.ButtonEnable = false;
                                    vant.Notify({ type: 'warning', message: '支付失败' + res.err_msg });
                                }
                            }
                        );
     ");
            WriteLiteral(@"               }).catch(function (err) {
                        setTimeout(() => {
                            vant.Toast({
                                icon: 'cross',
                                type: 'fail',
                                message: err,
                                duration: 0,
                                forbidClick: true
                            });
                        }, 600)
                    });
                }).catch(err => {
                    //下单失败
                    alert(err);
                })
            }, GetUserInfo() {
                axios({
                    method: 'get',
                    url: '/ChatGPT/My/GetInfoModel',
                    headers: {
                        'Content-Type': 'application/json; charset=UTF-8'
                    },
                }).then(res => {
                    this.UserInfo = res;
                }).catch(err => {

                })
            },
            GetCommodit");
            WriteLiteral(@"yList() {
                axios({
                    method: 'get',
                    url: '/ChatGPT/PayPage/GetCommodityList',
                    headers: {
                        'Content-Type': 'application/json; charset=UTF-8'
                    },
                }).then(res => {
                    this.CommodityList = res;
                    this.radio = res[0].ID
                }).catch(err => {

                })
            }
        },
        created() {
            this.GetUserInfo();
            this.GetCommodityList();
        },
        mounted() {

        }
    })
</script>");
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
