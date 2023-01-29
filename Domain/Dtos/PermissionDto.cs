using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class PermissionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "PermissionName is empty")]
        public string PermissionName { get; set; }

    }
}