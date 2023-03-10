#pragma checksum "E:\ChatGPT\ChatGPT\ChatGPT_Wx\Areas\ChatGPT\Views\AI\StreamAI.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8e3113279c4b95728265d9b67262592383b9c4c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ChatGPT_Views_AI_StreamAI), @"mvc.1.0.view", @"/Areas/ChatGPT/Views/AI/StreamAI.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8e3113279c4b95728265d9b67262592383b9c4c", @"/Areas/ChatGPT/Views/AI/StreamAI.cshtml")]
    #nullable restore
    public class Areas_ChatGPT_Views_AI_StreamAI : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/signalr/signalr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\ChatGPT\ChatGPT\ChatGPT_Wx\Areas\ChatGPT\Views\AI\StreamAI.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8e3113279c4b95728265d9b67262592383b9c4c3499", async() => {
                WriteLiteral(@"
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <meta name=""viewport""
          content=""width=device-width, initial-scale=1, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"" />
    <link rel=""stylesheet"" href=""/lib/vant/css/index.css"" />
    <link href=""/ChatGPT_Wx/Style.css"" rel=""stylesheet"" />
");
                WriteLiteral(@"    <style>
        .scroll-container {
            scroll-behavior: smooth;
            -webkit-overflow-scrolling: touch;
        }

        html {
            background-color: #FFFFFF;
        }
    </style>
    <style>
        .div_AI {
            margin: 8px;
            float: left;
            width: 98%;
        }

        .AI_Img {
            width: 40px;
            height: 40px;
            float: left;
        }

        .AI_Msg {
            max-width: 80%;
            float: left;
            /* min-width: 20%;*/
        }

        .AIPopou {
            max-width: 80%;
            float: left;
            min-width: 20%;
        }

        .AIsquare {
            position: relative;
            background: #ededed;
            margin-left: 20px;
            padding: 5px;
            border-radius: 5px;
        }

        .AItriangle {
            z-index: -10;
            position: absolute;
            top: 5px;
            left: -20px;
      ");
                WriteLiteral(@"      width: 0;
            height: 0;
            border-style: solid;
            border-width: 5px;
            border-right-width: 20px;
            border-color: transparent #ededed transparent transparent;
            font-size: 0;
            line-height: 0;
        }

        .text {
            text-indent: 1em;
            line-height: 24px;
            font-size: 15px;
            margin: 0;
            width: 100%;
            word-wrap: break-word;
            margin-top: 7px;
            margin-bottom: 7px;
            margin-right: 10px;
        }
    </style>
    <style>
        .div_Player {
            margin: 8px;
            float: right;
            width: 80%;
        }

        .Player_Msg {
            max-width: 100%;
            margin-right: 23px;
            float: right;
        }

        .POsquare {
            position: relative;
            background-color: #1989fa;
            padding: 5px;
            color: #fff;
            border-r");
                WriteLiteral(@"adius: 5px;
            width: 100%;
        }

        .POtriangle {
            z-index: -10;
            position: absolute;
            top: 5px;
            right: -17px;
            width: 0;
            height: 0;
            border-style: solid;
            border-width: 5px;
            border-left-width: 20px;
            border-color: transparent transparent transparent #1989fa;
            font-size: 0;
            line-height: 0;
        }

        .potext {
            line-height: 24px;
            font-size: 15px;
            margin: 0;
            width: 100%;
            word-wrap: break-word;
            max-width: 100%;
            min-width: 28px;
            text-align: left;
            /*white-space: pre-wrap;*/
        }
    </style>
    <style>
        .bottom {
            position: fixed;
            width: 100%;
            height: 60px;
            background-color: #f3f3f3;
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8e3113279c4b95728265d9b67262592383b9c4c7987", async() => {
                WriteLiteral(@"
    <div id=""app"" v-cloak>
        <div id=""scroll"" style=""width: 100%; float: left; max-height: 100%;"" class=""scroll-container"">
            <div class=""div_AI"">
                <div class=""AI_Img"">
                    <van-image width=""100%""
                               height=""100%""
                               src=""/ChatGPT_Wx/Img/ChatGPT.png""></van-image>
                </div>
                <div class=""AI_Msg"">
                    <div class=""AIsquare"">
                        <p class=""AItriangle""></p>
                        <div style=""max-width: 100%; min-width: 28px;"">
                            <div class=""potext"">你好！我是最强人工智能ChatGPT，我能回答你的所有问题，请和我聊天吧。</div>
                        </div>
                    </div>
                </div>
            </div>
            <div v-for=""(item,index) in context"" :key=""index"">
                <div class=""div_Player"" v-if=""item.question"">
                    <div class=""Player_Msg"">
                        <div class=""POsquare"">");
                WriteLiteral(@"
                            <p class=""POtriangle""></p>
                            <div class=""potext"">
                                {{item.question}}
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""div_AI"" v-if=""item.answer"">
                    <div class=""AI_Img"">
                        <van-image width=""100%""
                                   height=""100%""
                                   src=""/ChatGPT_Wx/Img/ChatGPT.png""></van-image>
                    </div>
                    <div class=""AI_Msg"">
                        <div class=""AIsquare"">
                            <p class=""AItriangle""></p>
                            <div style=""max-width: 100%; min-width: 28px;"">
                                <van-loading color=""#000000"" style=""display: inline; line-height: 24px; margin-left: 7px;"" size=""16px"" v-if=""item.answer==='loding'"">
                                </van-loading>");
                WriteLiteral(@"
                                <div class=""potext"" v-else style=""white-space: pre-wrap;"">{{item.answer}}</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""bottom"">
                <div class=""van-cell van-cell--center van-field"" style=""background-color: #f3f3f3;"">
                    <div class=""van-cell__value van-cell__value--alone van-field__value"">
                        <div class=""van-field__body"">
                            <input type=""text"" placeholder=""请输入您想咨询的问题"" class=""van-field__control""
                                   v-model=""text"" style=""background-color: #fff; height: 32px; height: 40px;padding-left: 15px; "" />
                            <div class=""van-field__button"">
                                <van-popover v-model=""showPopover"" trigger=""click"" :actions=""actions""
                                             ");
                WriteLiteral(@"@select=""onSelect"" placement=""top-end"">
                                    <template #reference>
                                        <van-button size=""small"" type=""info"" icon=""bars"" plain>
                                            菜单
                                        </van-button>
                                    </template>
                                </van-popover>
                                <transition name=""van-slide-right"">
                                    <van-button size=""small"" type=""info"" style=""width: 62px;""
                                                icon=""share"" v-show=""SendButVisible"" :loading=""ButLoding"" ");
                WriteLiteral(@"@click=""Send"">
                                        发送
                                    </van-button>
                                </transition>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style=""height:110px;width:100%;float:left;""></div>
        </div>
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
            WriteLiteral("\r\n<!-- 引入 Vue 和 Vant 的 JS 文件 -->\r\n<script src=\"/lib/vue/vue.js\"></script>\r\n<script src=\"/lib/vant/js/vant.js\"></script>\r\n<script src=\"/lib/axios/axios.js\"></script>\r\n<script src=\"/ChatGPT_Wx/Script/script.js\"></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8e3113279c4b95728265d9b67262592383b9c4c13551", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>
    // 在 #app 标签下渲染一个按钮组件
    new Vue({
        el: '#app',
        data: {
            ButLoding: false,//发送按钮loding
            SendButVisible: false,//文本框有文字后展示发送按钮
            text: '',
            context: [],
            showPopover: false,
            actions: [{ text: '重启话题' }],
            connection: null,
            NowContext: {},
            scroll: null
        },
        methods: {
            contion() {
                vant.Toast.loading({
                    message: 'AI服务链接中...',
                    forbidClick: true,
                    duration: 0,
                    forbidClick: true
                });
                //获取API地址，然后创建连接
                axios({
                    method: 'get',
                    url: '/ChatGPT/AI/GetAPI_Url',
                    headers: {
                        'Content-Type': 'application/json; charset=UTF-8',
                        'No-Loding': true
                    },
                }).then((res) => ");
            WriteLiteral(@"{
                    const that = this;
                    that.connection = new signalR.HubConnectionBuilder().withUrl(res + '/chatHub').build();//https://localhost:5001/chatHub
                    that.connection.on(""ReceiveMessage"", function (user, message) {
                        if (message == 'CHATGPTEND') {
                            return;//流式返回完成
                        }
                        if (message.indexOf(""ERROR"") != -1) {
                            vant.Dialog.confirm({
                                title: '异常',
                                message: '老外服务器不给力：' + message,
                                confirmButtonText: '再试试',
                                cancelButtonText: '忍了',
                            }).then(() => {
                                // on confirm
                                let Test = that.context[that.context.length - 1].question;
                                that.context.pop();
                                that.text = Test;");
            WriteLiteral(@"
                                that.Send();
                            }).catch(() => {
                                // on cancel
                                that.context.pop();
                            });
                            return;
                        }
                        if (that.NowContext.answer === 'loding') {
                            that.NowContext.answer = '';
                            console.log(that.NowContext.answer);
                        } else if (that.NowContext.answer === '' && message === '\n') {

                        } else {
                            that.NowContext.answer = that.NowContext.answer += message;
                        }
                        setTimeout(() => {
                            SmoothVerticalScrolling(that.scroll, 500, ""center"");
                        }, 200);
                    });
                    that.connection.start().then(function () {
                        //连接成功
                    ");
            WriteLiteral(@"    vant.Toast.clear();
                    }).catch(function (err) {
                        return console.error(err.toString());
                    });
                }).catch((err) => {
                    vant.Toast.fail(err);
                })
            },
            //气泡选择事件
            onSelect(val) {
                if (val.text === '重启话题') {
                    this.context = [];
                }
            },
            Signalr(sendMsg, context) {
                this.connection.invoke(""SendMessage"", '', sendMsg).catch(function (err) {
                    console.error(err);
                    vant.Dialog.confirm({
                        title: '异常',
                        message: '链接异常断开',
                        confirmButtonText: '重连',
                        showCancelButton: false
                    }).then(() => {
                        window.location.reload();
                    }).catch(() => {
                        // on cancel
                 ");
            WriteLiteral(@"   });
                });
                this.NowContext = context;
            },
            Send() {
                if (!this.text) {
                    vant.Notify({ type: 'warning', message: '内容不得为空' });
                    return;
                }
                //先校验权限是否允许发送
                axios({
                    method: 'get',
                    url: '/ChatGPT/AI/Check',
                    params: {
                        Text: this.text
                    },
                    headers: {
                        'Content-Type': 'application/json; charset=UTF-8',
                        'No-Loding': true
                    },
                }).then((res) => {
                    //this.ButLoding = true;
                    let msg = document.getElementById('scroll'); // 获取对象
                    //调用请求
                    let text = this.text;
                    this.text = '';
                    let Body = {
                        prompt: text,
         ");
            WriteLiteral(@"               history: JSON.parse(JSON.stringify(this.context))
                    }
                    let context = {
                        question: text,
                        answer: 'loding'
                    };
                    this.Signalr(JSON.stringify(Body), context);
                    this.context.push(context);
                    setTimeout(() => {
                        SmoothVerticalScrolling(msg, 500, ""center"");
                    }, 200);
                }).catch((err) => {
                    if (err.indexOf('会员') != -1) {
                        //会员充值提示
                        vant.Dialog.confirm({
                            title: '提示',
                            message: err,
                            confirmButtonText: '开通会员',
                            cancelButtonText: '取消',
                        }).then(() => {
                            parent.window.HomeVue.HomeHref('/ChatGPT/Pay/PayMember');
                        }).catch(() => {
  ");
            WriteLiteral(@"                          // on cancel
                        });
                    } else {
                        //敏感词
                        vant.Dialog.alert({
                            title: '提示',
                            message: err,
                        }).then(() => {
                            // on close
                        });
                    }
                })
            }
        },
        watch: {
            text(val) {
                if (val) {
                    this.SendButVisible = true
                } else {
                    this.SendButVisible = false
                }
            },
        },
        created() {
            this.contion();
        },
        mounted() {
            this.scroll = document.getElementById('scroll'); // 获取对象
        }
    });
    function SmoothVerticalScrolling(e, time, where) {
        var eTop = where == ""top"" ? (e.getBoundingClientRect().top < 2000 ? e.getBoundingClientRect().top - 1000 ");
            WriteLiteral(@": e.getBoundingClientRect().top) : (e.getBoundingClientRect().bottom > 2000 ? e.getBoundingClientRect().bottom + 1000 : e.getBoundingClientRect().bottom);
        var eAmt = eTop / 100;
        var curTime = 0;
        while (curTime <= time) {
            window.setTimeout(SVS_B, curTime, eAmt, where);
            curTime += time / 100;
        }
    }
    function SVS_B(eAmt, where) {
        window.scrollBy(0, eAmt);
    }
</script>
</html>");
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
