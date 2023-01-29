using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Role Name is empty")]
        public string RoleName { get; set; }

        public List<RolePermission> RolePermissions { get; set; }
        public List<UserRole> UserRoles{ get; set; }





    }
}