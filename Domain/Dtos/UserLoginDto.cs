using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class UserLoginDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "LoginDate is empty")]
        public DateTime LoginDate { get; set; }
        
        [Required(ErrorMessage = "Loginout is empty")]
        public DateTime LogoutDate { get; set; }

    }
}