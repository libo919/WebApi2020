using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi2020.DB.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; } = string.Empty;

        public int Del { get; set; }
    }
}
