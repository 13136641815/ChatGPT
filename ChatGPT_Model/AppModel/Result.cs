namespace ChatGPT_Model.AppModel
{
    public class Result
    {
        /// <summary>
        /// 状态码 200成功 其他失败 默认200
        /// </summary>
        public int CODE { get; set; } = ResultCode.Success;
        /// <summary>
        /// 业务数据Json 默认空
        /// </summary>
        public object DATA { get; set; } = "";
        /// <summary>
        /// 响应提示 默认成功
        /// </summary>
        public object MSG { get; set; } = "成功";
    }
}
