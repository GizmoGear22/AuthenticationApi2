using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NewUserModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string CheckPassword { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        public string Role { get; set; } = "RegUser";
    }

    public enum UserRoles
    {
        Admin,
        RegUser
    }
}
