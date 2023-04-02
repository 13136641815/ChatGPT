//通用函数：阻止页面在框架外打开
if (self == top) {
   // window.open("/", "_self");
}
function getURLParams() {
    const searchURL = location.search; // 获取到URL中的参数串
    const params = new URLSearchParams(searchURL);
    const valueObj = Object.fromEntries(params); // 转换为普通对象
    return valueObj;
}