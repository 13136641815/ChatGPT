//获取人员基本信息
window.APP_GetUserInfoAsync = async function GetUserInfoAsync() {
    return await AxiosPromise('/ChatGPT/My/GetInfoModel', 'get', {});
}