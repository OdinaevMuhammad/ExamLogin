using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserLogin
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "LoginDate is empty")]
        public DateTime LoginDate { get; set; }
        
        [Required(ErrorMessage = "Loginout is empty")]
        public DateTime LogoutDate { get; set; }

    }
}