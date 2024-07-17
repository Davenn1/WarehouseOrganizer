using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wearhouse3.Class
{
    [Table("Users")]
    public class User
    {
        [Key]
        [MaxLength(36)]
        public string UserID { get; set; }

        [MaxLength(255)]

        public string Name { get; set; }

        [MaxLength(255)]

        public string Email { get; set; }

        [MaxLength(255)]

        public string Password { get; set; }

    }
}
