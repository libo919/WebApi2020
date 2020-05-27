using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi2020.Models
{
    /// <summary>
    /// 组织/机构
    /// </summary>
    public class SysOrg
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
        /// 唯一ID
        /// </summary>
        public string SID { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户映射
        /// </summary>
        public ICollection<SysUserOrgMapping> SysUserOrgMapping { get; set; }
    }
}
