using System.ComponentModel.DataAnnotations;

namespace WebApi2020.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SysUserDetail
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public SysUser SysUser { get; set; }
    }
}