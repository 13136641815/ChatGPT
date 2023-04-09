//获取人员基本信息
window.APP_GetUserInfoAsync = async function GetUserInfoAsync() {
	return await AxiosPromise('/ChatGPT/My/GetInfoModel', 'get', {});
}
window.APP_Wxshare = function Wxshare() {
	const wx_invite_url = location.href;
	AxiosAsync('/ChatGPT/Home/GetWxShare', 'get', { HtmlURL: wx_invite_url }, true).then(res => {
		wx.config({
			debug: false, //调式模式，设置为ture后会直接在网页上弹出调试信息，用于排查问题
			appId: res.appId,
			timestamp: parseInt(res.timeStamp),
			nonceStr: res.nonceStr,
			signature: res.QM,
			jsApiList: [ //需要使用的网页服务接口
				'checkJsApi', //判断当前客户端版本是否支持指定JS接口
				'updateAppMessageShareData',//分享到微博
				'updateTimelineShareData',
				'onMenuShareWeibo'
			]
		});
		console.log(1);
		wx.ready(function () {   //需在用户可能点击分享按钮前就先调用
			wx.updateAppMessageShareData({
				title: res.nTitle, // 分享标题
				desc: res.Desc, // 分享描述
				link: res.Link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
				imgUrl: res.ImgUrl, // 分享图标
				success: function () {
				}
			});
			wx.ready(function () {      //需在用户可能点击分享按钮前就先调用
				wx.updateTimelineShareData({
					title: res.nTitle, // 分享标题
					link: res.Link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
					imgUrl: res.ImgUrl, // 分享图标
					success: function () {
						// 设置成功
					}
				})
			});
			wx.onMenuShareWeibo({
				title: res.nTitle, // 分享标题
				desc: res.Desc, // 分享描述
				link: res.Link, // 分享链接，该链接域名或路径必须与当前页面对应的公众号JS安全域名一致
				imgUrl: res.ImgUrl, // 分享图标
				success: function () {
					// 用户确认分享后执行的回调函数
				},
				cancel: function () {
					// 用户取消分享后执行的回调函数
				}
			});
		});
		console.log(2);
	}).catch(err => {

	});


};