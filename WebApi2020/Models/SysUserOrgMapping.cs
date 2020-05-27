using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi2020.Models
{
    public class SysUserOrgMapping
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int ID { get; set; }

        public SysUser SysUser { get; set; }
        public SysOrg SysOrg { get; set; }

        public bool IsAdmin { get; set; }

    }
}
