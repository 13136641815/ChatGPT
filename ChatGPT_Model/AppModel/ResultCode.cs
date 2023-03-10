namespace ChatGPT_Model.AppModel
{
    public class ResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        public static int Success { get; } = 200;//成功并完整返回数据
        /// <summary>
        /// 空数据
        /// </summary>
        public static int Empty { get; } = 0;//成功但数据有预料的为空
        /// <summary>
        /// 身份丢失
        /// </summary>
        public static int NoIdentity { get; } = 203;//身份丢失
        /// <summary>
        /// 异常
        /// </summary>
        public static int Error { get; } = 500;//程序catch报错

        /// <summary>
        /// 数据异常
        /// </summary>
        public static int DataError { get; } = 400;//数据格式错误
    }
}
