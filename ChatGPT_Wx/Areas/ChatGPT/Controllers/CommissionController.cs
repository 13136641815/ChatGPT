using ChatGPT_Model.AppModel;
using Microsoft.AspNetCore.Mvc;
using ChatGPT_Model;
using SqlSugar;
using ChatGPT_Mapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class CommissionController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommissionController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
            var setmodel = await setApp.GetFirstAsync();
            ViewBag.Title = setmodel.Title;
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetListPage(PageParams Page, GPT_Commission model, DateTimeParams Time)
        {
            Mapper_GPT_Commission app = new Mapper_GPT_Commission();
            RefAsync<int> DataCount = 0;
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var Usermodel = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            model.Push_WxOpenID = Usermodel.UserInfo.openid;
            var list = await app.GetListPageAsync(Page, model, Time, DataCount);
            var SUM = await app.GetListSumAsync(Page, model, Time, DataCount);
            return Json(new Result()
            {
                DATA = new ResultPage()
                {
                    DATACOUNT = DataCount,
                    DATA = list,
                    DATASUM = SUM == null ? 0.00 : SUM
                }
            });
        }
        [HttpGet]
        public async Task<JsonResult> GetUserListPage()
        {
            Mapper_GPT_User app = new Mapper_GPT_User();
            RefAsync<int> DataCount = 0;
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var model = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            var list = await app.GetComListAsync(model.UserInfo.openid);
            return Json(new Result()
            {
                DATA = list
            });
        }
        /// <summary>
        /// 校验看是否允许提现
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> ChekedIsOk()
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var model = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            Mapper_GPT_User userApp = new Mapper_GPT_User();
            var modelNew = userApp.GetFirst(model.UserInfo.openid);
            if (modelNew.AccountNum == null || modelNew.AccountNum == "" || modelNew.AccountType == null)
            {
                return Json(new Result()
                {
                    CODE = ResultCode.Empty,
                    MSG = $"请先返回上一页完善提现账户信息！"
                });
            }
            Mapper_GPT_CashWithdrawal Wapp = new Mapper_GPT_CashWithdrawal();
            var CashModel = await Wapp.GetModel(model.UserInfo.openid);
            if (CashModel == null)
            {
                Mapper_GPT_Commission app = new Mapper_GPT_Commission();
                PageParams Page = new PageParams();
                Page.PageNum = 1;
                Page.PageSize = 1000;
                GPT_Commission Cmodel = new GPT_Commission();
                Cmodel.CheckState = 0;
                Cmodel.Push_WxOpenID = model.UserInfo.openid;
                DateTimeParams Time = new DateTimeParams();
                RefAsync<int> DataCount = 0;
                await app.GetListPageAdminAsync(Page, Cmodel, Time, DataCount);
                var SUM = await app.GetListSumAdminAsync(Page, Cmodel, Time, DataCount);
                Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
                var SetModel = await setApp.GetFirstAsync();
                if (SetModel.DoorJe == null) SetModel.DoorJe = decimal.Parse("0.00");
                if (SUM >= SetModel.DoorJe)
                {
                    return Json(new Result()
                    {
                        CODE = ResultCode.Success,
                        DATA = new obj()
                        {
                            DATACOUNT = DataCount,
                            SUM = SUM,
                        }
                    });
                }
                else
                {
                    return Json(new Result()
                    {
                        CODE = ResultCode.Empty,
                        MSG = $"满{SetModel.DoorJe}元才可发起提现！"
                    });
                }
            }
            else
            {
                return Json(new Result()
                {
                    CODE = ResultCode.Empty,
                    MSG = "已存在未处理的提现申请"
                });
            }
            return Json(new Result()
            {
                CODE = ResultCode.Empty,
                MSG = "失败"
            });
        }
        /// <summary>
        /// 提现
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Account()
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("H5COOKIES", out string value);
            var model = JsonConvert.DeserializeObject<H5Cookie>(Tools.AES.staticKeyTo_DecryptAES(value));//获取COOKIE身份
            Mapper_GPT_User userApp = new Mapper_GPT_User();
            var modelNew = userApp.GetFirst(model.UserInfo.openid);
            Mapper_GPT_CashWithdrawal Wapp = new Mapper_GPT_CashWithdrawal();
            var CashModel = await Wapp.GetModel(model.UserInfo.openid);
            if (CashModel == null)
            {
                Mapper_GPT_Commission app = new Mapper_GPT_Commission();
                PageParams Page = new PageParams();
                Page.PageNum = 1;
                Page.PageSize = 1000;
                GPT_Commission Cmodel = new GPT_Commission();
                Cmodel.CheckState = 0;
                Cmodel.Push_WxOpenID = model.UserInfo.openid;
                DateTimeParams Time = new DateTimeParams();
                RefAsync<int> DataCount = 0;
                var list = await app.GetListPageAdminAsync(Page, Cmodel, Time, DataCount);
                var SUM = await app.GetListSumAdminAsync(Page, Cmodel, Time, DataCount);
                Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
                var SetModel = await setApp.GetFirstAsync();
                if (SetModel.DoorJe == null) SetModel.DoorJe = decimal.Parse("0.00");
                if (SUM >= SetModel.DoorJe)
                {
                    var db = SugarConfig.CretClient();
                    await db.BeginTranAsync();
                    //可提现，插入提现申请
                    var i = await Wapp.Add(new GPT_CashWithdrawal()
                    {
                        State = 0,
                        NikeName = model.UserInfo.nickname,
                        Opneid = model.UserInfo.openid,
                        AccountType = modelNew.AccountType,
                        AccountNum = modelNew.AccountNum,
                        ZBS = DataCount,
                        ZJE = decimal.Parse(SUM.ToString())
                    }, db);
                    //插入成功，修改状态
                    list.ForEach(it => it.CheckState = 2);
                    int UI = await app.UpdateCheck2State(list, db);
                    if (UI > 0 && i > 0)
                    {
                        await db.CommitTranAsync();
                        return Json(new Result()
                        {
                            CODE = ResultCode.Success
                        });
                    }
                    await db.RollbackTranAsync();
                }
                else
                {
                    return Json(new Result()
                    {
                        CODE = ResultCode.Empty,
                        MSG = $"满{SetModel.DoorJe}元才可发起提现！"
                    });
                }
            }
            else
            {
                return Json(new Result()
                {
                    CODE = ResultCode.Empty,
                    MSG = "已存在未处理的提现申请"
                });
            }
            return Json(new Result()
            {
                CODE = ResultCode.Empty,
                MSG = "失败"
            });
        }
        class obj
        {
            public int DATACOUNT { get; set; }
            public decimal? SUM { get; set; }
        }
    }
}
