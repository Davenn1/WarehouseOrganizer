using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Wearhouse3.Class
{
    [Table("Category")]
    public class Category
    {
        [MaxLength(255)]
        [Key]
        public string CategoryID { get; set; }

        
        [MaxLength(255)]
        public string CategoryName {
            get;set;
        }

        [MaxLength(36)]

        public string UserID {
            get;set;
        }
    }
}
