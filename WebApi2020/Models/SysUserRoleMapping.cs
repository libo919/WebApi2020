using System.ComponentModel.DataAnnotations;

namespace WebApi2020.Models
{
    public class SysUserRoleMapping
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        public int SysUserID { get; set; }
        public int SysRoleID { get; set; }

        public SysUser SysUser { get; set; }
        public SysRole SysRole { get; set; }
    }
}