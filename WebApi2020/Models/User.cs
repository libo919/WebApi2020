using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2020.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("User")]
    public class User
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 是否删除 0否 1是
        /// </summary>
        public int Del { get; set; }
    }
}
