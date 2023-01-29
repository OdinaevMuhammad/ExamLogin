using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "RoleName is empty")]
        public string RoleName { get; set; }

    }
}