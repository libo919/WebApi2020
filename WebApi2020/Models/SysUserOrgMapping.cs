using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi2020.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SysUserOrgMapping
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SysUser SysUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SysOrg SysOrg { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public bool IsAdmin { get; set; }

    }
}
