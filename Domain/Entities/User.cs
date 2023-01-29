using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage ="Email is empty")]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is empty")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }

        public List<UserRole> UserRoles{ get; set; }

    }
}