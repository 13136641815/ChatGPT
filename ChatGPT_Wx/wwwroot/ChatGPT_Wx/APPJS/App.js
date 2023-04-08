//获取人员基本信息
window.APP_GetUserInfoAsync = async function GetUserInfoAsync() {
    return await AxiosPromise('/ChatGPT/My/GetInfoModel', 'get', {});
}
window.APP_Wxshare = async function Wxshare() {

    wx.config({
        debug: false, //调式模式，设置为ture后会直接在网页上弹出调试信息，用于排查问题
        appId: Appid,
        timestamp: parseInt(TimeStamp),
        nonceStr: NonceStr,
        signature: QM,
        jsApiList: [ //需要使用的网页服务接口
            'checkJsApi', //判断当前客户端版本是否支持指定JS接口
            'onMenuShareTimeline', //分享给好友
            'onMenuShareAppMessage', //分享到朋友圈
            'onMenuShareQQ', //分享到QQ
            'onMenuShareWeibo' //分享到微博
        ]
    });
    wx.ready(function () {   //需在用户可能点击分享按钮前就先调用
        wx.onMenuShareAppMessage({
            title: Title, // 分享标题
            desc: Desc, // 分享描述
            link: Link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
            imgUrl: ImgUrl, // 分享图标
            success: function () {
            }
        });
    });

};