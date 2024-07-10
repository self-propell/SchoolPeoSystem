using System.ComponentModel.DataAnnotations.Schema;

namespace SchPeoSystem.Models
{
    public class MTeacher:BasicModel
    {
        /// <summary>
        /// 教师唯一标识，主键
        /// </summary>
        [Column("teacher_id")]
        public int TeacherId { get; set; }

        /// <summary>
        /// 教师姓名
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 教师性别
        /// </summary>
        [Column("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Column("id_number")]
        public string IdNumber { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 联系邮箱地址
        /// </summary>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// 就职日期【创建条目填写】
        /// </summary>
        [Column("enrollment_date")]
        public DateTime EnrollmentDate { get; set; }

        /// <summary>
        /// 合同到期日期
        /// </summary>
        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// 职称【教授/副教授等】
        /// </summary>
        [Column("job_title")]
        public string JobTitle { get; set; }

        /// <summary>
        /// 职位【院长/副院长等】
        /// </summary>
        [Column("job_position")]
        public string JobPosition { get; set; }

        /// <summary>
        /// 所属学院ID
        /// </summary>
        [Column("school_id")]
        public int SchoolId { get; set; }

        /// <summary>
        /// 是否有编制
        /// </summary>
        [Column("is_budgeted_posts")]
        public bool IsBudgetedPosts { get; set; }

        /// <summary>
        /// 是否已离职
        /// </summary>
        [Column("is_departed")]
        public bool IsDeparted { get; set; }

        /// <summary>
        /// 离职日期【离职时填写】
        /// </summary>
        [Column("departed_date")]
        public DateTime? DepartedDate { get; set; }

        /// <summary>
        /// 离职原因【离职时填写】
        /// </summary>
        [Column("departed_reason")]
        public string? DepartedReason { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [Column("description")]
        public string? Description { get; set; }

        /// <summary>
        /// 创建人【创建条目时填写】
        /// </summary>
        [Column("create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建条目时间【创建条目时填写】
        /// </summary>
        [Column("create_timestamp")]
        public DateTime CreateTimestamp { get; set; }

        /// <summary>
        /// 上次修改信息经手人
        /// </summary>
        [Column("update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 上次修改时间
        /// </summary>
        [Column("update_timestamp")]
        public DateTime UpdateTimestamp { get; set; }

        /// <summary>
        /// 条目是否已注销删除
        /// </summary>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 条目删除操作人
        /// </summary>
        [Column("delete_by")]
        public string? DeleteBy { get; set; }

        /// <summary>
        /// 条目删除时间
        /// </summary>
        [Column("delete_timestamp")]
        public DateTime? DeleteTimestamp { get; set; }

        /// <summary>
        /// 条目删除原因
        /// </summary>
        [Column("delete_reason")]
        public string? DeleteReason { get; set; }


    }
}
