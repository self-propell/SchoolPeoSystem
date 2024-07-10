namespace SchPeoSystem.Models
{
    public class MAccount:BasicModel
    {
        /// <summary>
        /// 用户唯一标识，主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 登录账号【学号/工号】
        /// </summary>
        public string Login_Id { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 账号冻结状态 0：正常 1：冻结
        /// </summary>
        public bool Is_Freezed { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Create_By { get; set; }
        /// <summary>
        /// 该账号创建时间
        /// </summary>
        public DateTime Create_Timestamp { get; set; }
        /// <summary>
        /// 上次修改信息经手人
        /// </summary>
        public string? Update_By { get; set; }
        /// <summary>
        /// 账号信息上次修改时间
        /// </summary>
        public DateTime? Update_Timestamp { get; set; }
        /// <summary>
        /// 账号是否已注销删除
        /// </summary>
        public bool Is_Deleted { get; set; }
        /// <summary>
        /// 账号删除操作人
        /// </summary>
        public string? Delete_By { get; set; }
        /// <summary>
        /// 账号标记为删除时间
        /// </summary>
        public DateTime? Delete_Timestamp { get; set; }
        /// <summary>
        /// 账号被标记为删除的原因
        /// </summary>
        public string? Delete_Reason { get; set; }


    }
}
