using System.ComponentModel.DataAnnotations;

namespace WebApi2020.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SysUserRoleMapping
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SysUserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SysRoleID { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public SysUser SysUser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SysRole SysRole { get; set; }
    }
}