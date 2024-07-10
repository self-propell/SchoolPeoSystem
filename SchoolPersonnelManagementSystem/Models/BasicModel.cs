namespace SchPeoSystem.Models
{
    /// <summary>
    /// 基础类操作信息
    /// </summary>
    public abstract class BasicModel
    {
        /// <summary>
        /// 本次操作是否成功
        /// </summary>
        /// <returns>bool 1:</returns>
        public bool isFailed { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
        public DateTime _reqTime;
        public DateTime ReqTime 
        { 
            get { return ReqTime; }
            set { this.ReqTime = DateTime.Now; } 
        }
        public string DataModel { get; set; }
    }
}
