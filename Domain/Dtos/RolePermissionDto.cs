using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class RolePermissionDto
    {
        public int Id { get; set; }
        public int RoleId{ get; set; }
        public int PermissionId{ get; set; } 
            
    }
}