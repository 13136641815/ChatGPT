using ChatGPT_Mapper;
using ChatGPT_Model;
using ChatGPT_Model.AppModel;
using ChatGPT_Service.AI;
using ChatGPT_Service.PayPage;
using ChatGPT_Wx.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ChatGPT_Wx.Areas.ChatGPT.Controllers
{
    [Area("ChatGPT")]
    public class PayController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PayController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PayMember()
        {
            Mapper_GPT_Setup setApp = new Mapper_GPT_Setup();
            var setmodel = await setApp.GetFirstAsync();
            ViewBag.Title = setmodel.Title;
            return View();
        }
        public IActionResult PayVIP()
        {
            return View();
        }
        public class order
        {
            public int ComID { get; set; }
        }
        [HttpPost]
        public async Task<JsonResult> DownOrder([FromBody] order O)
        {
            GetCookiesController app = new GetCookiesController(_httpContextAccessor);
            Mapper_GPT_Commodity CommodityApp = new Mapper_GPT_Commodity();
            Mapper_GPT_Order OrderApp = new Mapper_GPT_Order();
            Mapper_GPT_OrderCommodity OCApp = new Mapper_GPT_OrderCommodity();
            var ComModel = await CommodityApp.GetCommodityFirstAsync(O.ComID);
            var model = await app.GetInfoModelFromCookies();
            var db = SugarConfig.CretClient();
            await db.BeginTranAsync();
            GPT_Order OrderModel = new GPT_Order()
            {
                Stamp = DateTime.Now,
                State = 0,
                Channel = "微信H5",
                OrderNumber = OrderNo.GeneratOrderNo(),
                UserID = model.ID,
                OrderAmountYuan = Math.Round(((decimal)ComModel.CommodityPresentPrice / 100), 2),
                OrderAmountFen = ComModel.CommodityPresentPrice
            };
            var ID = await OrderApp.AddAsync(OrderModel, db);
            GPT_OrderCommodity OrderCommodityModel = new GPT_OrderCommodity()
            {
                Stamp = DateTime.Now,
                OrderNumber = OrderModel.OrderNumber,
                Discount = ComModel.Discount,
                CommodityName = ComModel.CommodityName,
                CommodityOriginalPrice = ComModel.CommodityOriginalPrice,
                CommodityPresentPrice = ComModel.CommodityPresentPrice,
                CommodityType = ComModel.CommodityType,
                Duration = ComModel.Duration,
                Explain = ComModel.Explain
            };
            var OCID = await OCApp.AddAsync(OrderCommodityModel, db);
            //下单时判断此人是不是被推荐的，需要将商品返利一并下单
            if (!string.IsNullOrEmpty(model.PushOpenID) && model.PushOpenID != "0" && ComModel.ShareCommission !> decimal.Parse("0.00"))
            {
                Mapper_GPT_User userApp = new Mapper_GPT_User();
                var PushModel = await userApp.GetModelFirstAsync(model.PushOpenID);//分佣者
                Mapper_GPT_Commission CommissionAPP = new Mapper_GPT_Commission();//需要将返利一起下单
                int CI = await CommissionAPP.AddAsync(new GPT_Commission()
                {
                    State = 0,
                    CheckState = 0,
                    Push_ID = PushModel.ID,
                    Push_WxOpenID = PushModel.WxOpenID,
                    Push_NikeName = PushModel.NikeName,
                    Buy_ID = model.ID,
                    Buy_WxOpenID = model.WxOpenID,
                    Buy_NikeName = model.NikeName,
                    OrderNumber = OrderModel.OrderNumber,
                    CommodityName = ComModel.CommodityName,
                    ShareCommission = ComModel.ShareCommission,
                    OrderAmountYuan = OrderModel.OrderAmountYuan,
                    Commission = Math.Round(((decimal)OrderModel.OrderAmountYuan * (decimal)ComModel.ShareCommission), 2)
                }, db);
            }
            if (ID > 0 && OCID > 0)
            {
                await db.CommitTranAsync();
                #region 加载上送腾讯包

                PayModel PayModel = new PayModel()
                {
                    out_trade_no = OrderModel.OrderNumber,
                    total_fee = ComModel.CommodityPresentPrice.ToString()
                };
                PayConfigParameter payconfig = new PayConfigParameter()
                {
                    body = "开通会员",//商品名称
                    notify_url = Request.HttpContext.Request.Host + "/ChatGPT/PayBack/WeChatBack",//回调地址
                };
                #endregion

                string PayData = AES.staticKeyTo_EncryptAES(JsonConvert.SerializeObject(PayModel));
                string PayConfig = AES.staticKeyTo_EncryptAES(JsonConvert.SerializeObject(payconfig));
                return Json(new Result()
                {
                    DATA = new PayParams()
                    {
                        PayData = PayData,
                        PayConfig = PayConfig,
                        OrderNo = OrderModel.OrderNumber
                    }
                });
            }
            else
            {
                await db.RollbackTranAsync();
            }
            return Json(new Result()
            {
                CODE = ResultCode.Empty
            });
        }
    }
}
