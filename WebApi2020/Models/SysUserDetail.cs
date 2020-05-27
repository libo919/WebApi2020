using System.ComponentModel.DataAnnotations;

namespace WebApi2020.Models
{
    public class SysUserDetail
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }


        public SysUser SysUser { get; set; }
    }
}