#pragma checksum "E:\ChatGPT\ChatGPT\ChatGPT_Wx\Areas\ChatGPT\Views\My\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "500a832a5202e24e64070a17f9a3d6eb3bb7489d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ChatGPT_Views_My_Index), @"mvc.1.0.view", @"/Areas/ChatGPT/Views/My/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"500a832a5202e24e64070a17f9a3d6eb3bb7489d", @"/Areas/ChatGPT/Views/My/Index.cshtml")]
    #nullable restore
    public class Areas_ChatGPT_Views_My_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "E:\ChatGPT\ChatGPT\ChatGPT_Wx\Areas\ChatGPT\Views\My\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "500a832a5202e24e64070a17f9a3d6eb3bb7489d2957", async() => {
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <meta name=""viewport""
          content=""width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"" />
    <link rel=""stylesheet"" href=""/lib/vant/css/index.css"" />
    <link href=""/ChatGPT_Wx/Style.css"" rel=""stylesheet"" />
    <title></title>
    <style>
        html {
            background-color: #e0f0ff;
        }

        .div_content {
        }

        .van-popup--bottom {
            bottom: 50px;
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "500a832a5202e24e64070a17f9a3d6eb3bb7489d4500", async() => {
                WriteLiteral(@"
    <div id=""app"" v-cloak>
        <div class=""div_top"">
            <div class=""Img"">
                <van-image round
                           width=""9rem""
                           height=""9rem""
                           :src=""UserInfo.WxHeadUrl"" style=""box-shadow: rgb(25, 137, 250) 0px 5px 0px -21px, rgb(25, 137, 250) 0px 0px 50px -11px""></van-image>
            </div>
            <div class=""Info"">
                <div>
                    <p class=""P_ID"">ID：{{UserInfo.ID}}</p>
                    <p class=""P_Name"">{{UserInfo.NikeName}}</p>
                    <van-tag type=""primary"" color=""#ffc800"" v-if=""UserInfo.IsShowTime"" size=""large"">SVIP</van-tag>
                    <van-tag color=""#8f8f8f"" v-else size=""large"">游客</van-tag>
                    <p class=""P_Tips"" v-if=""UserInfo.IsShowTime"">将于：{{UserInfo.BeOverdue_VIP}} 到期</p>
                    <p class=""P_Tips"" v-else>剩余体验次数{{UserInfo.Free_Second}}</p>
                </div>
            </div>
        </div>
        <div cl");
                WriteLiteral("ass=\"div_content\" style=\"margin-top:30px;\">\r\n            <van-cell-group inset>\r\n                <van-cell");
                BeginWriteAttribute("value", " value=\"", 1767, "\"", 1775, 0);
                EndWriteAttribute();
                WriteLiteral(" is-link ");
                WriteLiteral(@"@click=""GoUrl('/ChatGPT/Pay/PayMember')"">
                    <!-- 使用 title 插槽来自定义标题 -->
                    <template #title>
                        <span class=""custom-title"">充值会员</span>
                        <van-tag type=""danger"" color=""#ffc800"">SVIP</van-tag>
                    </template>
                </van-cell>
                <van-cell");
                BeginWriteAttribute("value", " value=\"", 2146, "\"", 2154, 0);
                EndWriteAttribute();
                WriteLiteral(" is-link ");
                WriteLiteral(@"@click=""showPopup=true"">
                    <!-- 使用 title 插槽来自定义标题 -->
                    <template #title>
                        <span class=""custom-title"">推广赚钱</span>
                        <van-tag type=""success"">赚</van-tag>
                    </template>
                </van-cell>
                <van-cell");
                BeginWriteAttribute("value", " value=\"", 2490, "\"", 2498, 0);
                EndWriteAttribute();
                WriteLiteral(" is-link ");
                WriteLiteral(@"@click=""show=true"">
                    <!-- 使用 title 插槽来自定义标题 -->
                    <template #title>
                        <span class=""custom-title"">卡密充值</span>
                        <van-tag type=""danger"">CDK</van-tag>
                    </template>
                </van-cell>
            </van-cell-group>
        </div>
        <van-dialog v-model=""show"" title=""卡密兑换"" show-cancel-button ");
                WriteLiteral("@confirm=\"confirmCard\" ");
                WriteLiteral(@"@cancel=""show=false;inputCard=''"">
            <van-cell-group>
                <van-field v-model=""inputCard"" placeholder=""请输入卡密""></van-field>
            </van-cell-group>
        </van-dialog>
        <van-action-sheet v-model=""showPopup"" :actions=""actions"" ");
                WriteLiteral("@select=\"onSelect\"></van-action-sheet>\r\n        <van-dialog v-model=\"RemarkShow\" title=\"分销说明\">\r\n            <div style=\"line-height: 25px; padding: 10px;white-space:pre-wrap;word-break: break-all;\">");
#nullable restore
#line 78 "E:\ChatGPT\ChatGPT\ChatGPT_Wx\Areas\ChatGPT\Views\My\Index.cshtml"
                                                                                                 Write(ViewBag.CommissionRemark);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n        </van-dialog>\r\n        <van-popup v-model=\"FormShow\" position=\"top\" :style=\"{ height: \'230px\' }\">\r\n            <van-cell-group style=\"margin-top:30px;\">\r\n                <van-form ");
                WriteLiteral(@"@submit=""onSubmit"">
                    <van-field name=""radio"" label=""账户类型"">
                        <template #input>
                            <van-radio-group v-model=""UserInfo.AccountType"" direction=""horizontal"">
                                <van-radio name=""微信"">微信</van-radio>
                                <van-radio name=""支付宝"">支付宝</van-radio>
                            </van-radio-group>
                        </template>
                    </van-field>
                    <van-field v-model=""UserInfo.AccountNum"" label=""收款账户""
                               name=""AccountNum""
                               placeholder=""请填写收款账户""
                               :rules=""[{ required: true, message: '请填写账户' }]""></van-field>
                    <div style=""margin: 16px;"">
                        <van-button round block type=""info"" native-type=""submit"">提交</van-button>
                    </div>
                </van-form>
            </van-cell-group>
        </van-popup>
    </div>
");
                WriteLiteral(@"    <script src=""/lib/vue/vue.js""></script>
    <script src=""/lib/vant/js/vant.js""></script>
    <script src=""/lib/axios/axios.js""></script>
    <script src=""/ChatGPT_Wx/Script/script.js""></script>
    <script>
        // 在 #app 标签下渲染一个按钮组件
        new Vue({
            el: '#app',
            data: {
                active: 0,
                route: [],
                Index: 0,
                TabbarShow: false,
                isHaveBill: false,
                UserInfo: {},
                show: false,
                inputCard: '',
                showPopup: false,
                actions: [{ name: '分销说明' }, { name: '推广码' }, { name: '佣金明细' }, { name: '收款账户' }],
                RemarkShow: false,
                FormShow: false,
            },
            methods: {
                onSubmit(values) {
                    axios({
                        method: 'put',
                        url: '/ChatGPT/My/UpdateAccountNum',
                        data: this.UserInfo,
       ");
                WriteLiteral(@"                 headers: {
                            'Content-Type': 'application/json; charset=UTF-8'
                        },
                    }).then(res => {
                        vant.Notify({ type: 'success', message: '保存成功', duration: 3000 });
                    }).catch(err => {
                        vant.Notify({ type: 'danger', message: err, duration: 2000 });
                    })
                    this.FormShow = false;
                },
                onSelect(item) {
                    this.showPopup = false;
                    this.show = false;
                    if (item.name == '分销说明') {
                        this.RemarkShow = true;
                    } else if (item.name == '推广码') {
                        axios({
                            method: 'get',
                            url: '/ChatGPT/My/GetMyQrCode',
                            headers: {
                                'Content-Type': 'application/json; charset=UTF-8'
            ");
                WriteLiteral(@"                },
                        }).then(res => {
                            vant.ImagePreview([res]);
                        }).catch(err => {

                        })
                    } else if (item.name == '佣金明细') {
                        this.GoUrl('/ChatGPT/Commission/Index')
                    } else {
                        this.FormShow = true
                    }
                },
                OpenDai() {

                },
                ResetTimes() {
                    axios({
                        method: 'get',
                        url: '/ChatGPT/Test/ResetTimes?OpenID=' + this.UserInfo.WxOpenID,
                        headers: {
                            'Content-Type': 'application/json; charset=UTF-8'
                        },
                    }).then(res => {
                        vant.Toast.success('操作成功！');
                    }).catch(err => {

                    })
                },
                NoVip() {
     ");
                WriteLiteral(@"               axios({
                        method: 'get',
                        url: '/ChatGPT/Test/NoVip?OpenID=' + this.UserInfo.WxOpenID,
                        params: {
                            OpenID: this.GetUserInfo.WxOpenID
                        },
                        headers: {
                            'Content-Type': 'application/json; charset=UTF-8'
                        },
                    }).then(res => {
                        vant.Toast.success('操作成功！');
                        this.GetUserInfo();
                    }).catch(err => {

                    })
                },
                VipTimeOut() {
                    axios({
                        method: 'get',
                        url: '/ChatGPT/Test/VipTimeOut?OpenID=' + this.UserInfo.WxOpenID,
                        params: {
                            OpenID: this.GetUserInfo.WxOpenID
                        },
                        headers: {
                            '");
                WriteLiteral(@"Content-Type': 'application/json; charset=UTF-8'
                        },
                    }).then(res => {
                        vant.Toast.success('操作成功！');
                        this.GetUserInfo();
                    }).catch(err => {

                    })
                },
                GoUrl(url) {
                    window.parent.HomeVue.HomeHref(url);
                },
                GetUserInfo() {
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
                confirmCard() {
                    if (!this.inputCard) {
                        vant.Notify({ type: 'danger', message: '请输入");
                WriteLiteral(@"卡密' });
                        return;
                    }
                    axios({
                        method: 'put',
                        url: '/ChatGPT/My/ExchangeCDK',
                        data: {
                            CDK: this.inputCard
                        },
                        headers: {
                            'Content-Type': 'application/json; charset=UTF-8'
                        },
                    }).then(res => {
                        this.show = false;
                        vant.Notify({ type: 'success', message: res, duration: 5000 });
                        this.inputCard = '';
                        this.GetUserInfo();
                    }).catch(err => {
                        vant.Notify({ type: 'danger', message: err });
                    })
                    // 危险通知


                },
                Call() {
                    //添加微信：wuyoukaoba
                    vant.Dialog.alert({
                        ");
                WriteLiteral(@"title: '客服微信',
                        message: 'wuyoukaoba',
                        confirmButtonText: '复制'
                    }).then(() => {
                        // on close
                        const copyToClipboard = str => {
                            if (navigator && navigator.clipboard && navigator.clipboard.writeText)
                                return navigator.clipboard.writeText(str);
                            return Promise.reject('The Clipboard API is not available.');
                        };
                        copyToClipboard('wuyoukaoba');
                        vant.Notify({ type: 'success', message: '已复制到剪贴板' });
                    });
                }
            },
            created() {
                this.GetUserInfo();
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
