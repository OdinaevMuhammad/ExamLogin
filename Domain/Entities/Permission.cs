using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "PermissionName is empty")]
        public string PermissionName { get; set; }

        public List<RolePermission> RolePermissions { get; set; }

    }
}