using System.ComponentModel.DataAnnotations;

namespace WebApi2020.Models
{
    public class Company
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int ID { get; set; }
    }
}