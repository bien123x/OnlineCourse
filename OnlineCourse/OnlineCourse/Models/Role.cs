using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        [Required, MaxLength(50)]
        public string RoleName { get; set; } = null!;

        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
