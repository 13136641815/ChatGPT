//通用函数：判断按钮权限
const ButPower = ((ThisCode, CodeList) => {
    let Have = false;
    CodeList.forEach((item) => {
        if (ThisCode === item.r_code) {
            Have = true;
            return Have;
        }
    })
    return Have;
})
//通用函数：阻止页面在框架外打开
if (self == top) {
    //window.open("/", "_self");
}
function getURLParams() {
    const searchURL = location.search; // 获取到URL中的参数串
    const params = new URLSearchParams(searchURL);
    const valueObj = Object.fromEntries(params); // 转换为普通对象
    return valueObj;
}


//*系统设置表
//**Code=业务代码
//**TheConfig=默认年度全部数据
//***返回结果=某个业务代码的整条数据
//***返回格式=JSON
function Get_SetUpAll(Code, TheConfig) {
    const TheResult = [];
    //判断长度
    if (TheConfig.length > 0) {
        TheConfig.forEach((item) => {
            //取代码相等的数据
            if (item.Code == Code) {
                TheResult.push(item);
            }
        });
    }
    return TheResult;
}

//*系统设置表
//**Field=对应字段名称
//**Code=业务代码
//**TheConfig=默认年度全部数据
//***返回结果=某个业务代码的某个字段值
//***返回格式=字符串
function Get_SetUpOne(Code, TheConfig) {
    let TheResult = "";
    //判断长度
    if (TheConfig.length > 0) {
        TheConfig.forEach((item) => {
            //判断业务代码
            if (item.Code == Code) {
                TheResult = item;
            }
        });
    }
    return TheResult;
}


//*数据字典子表
//**PCode=父级代码
//**TheConfig=默认年度全部数据
//***返回结果=某个父级代码的全部子字典
//***返回格式=JSON
function Get_SDI_All(PCode, TheConfig) {
    const TheResult = [];
    //判断长度
    if (TheConfig.length > 0) {
        TheConfig.forEach((item) => {
            //取父级代码相等的数据
            if (item.dcode == PCode) {
                TheResult.push(item);
            }
        });
    }
    return TheResult;
}

//*数据字典子表
//**Code=本级代码
//**TheConfig=某个父级代码全部数据
//***返回结果=某个字典代码的名称
//***返回格式=字符串
function Get_DicName(Code, TheConfig) {

    let DicName = '';
    var Arr = Code.split(',');
    //判断长度
    if (TheConfig.length > 0) {
        Arr.forEach((itemCode) => {
            TheConfig.forEach((item) => {
                //取本级代码相等的名称
                if (item.Itemcode == itemCode) {
                    DicName += `${item.ItemValue},`;
                }
            });
        });
        DicName = DicName.substring(0, DicName.lastIndexOf(','));
    }
    return DicName;
}

//默认分页数据集合
window.PageSizeList = [5, 10, 20, 50];