using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi2020.Models
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public class SysUser
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(200)]
        public string Password { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [StringLength(50)]
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [StringLength(200)]
        public string Email { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [StringLength(200)]
        public string Company { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public string Duty { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastLoginDate { get; set; }

        /// <summary>
        /// 组织映射
        /// </summary>
        public ICollection<SysUserOrgMapping> SysUserOrgMapping { get; set; }
    }
}