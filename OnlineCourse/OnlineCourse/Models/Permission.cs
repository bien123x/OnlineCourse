using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.Models
{
    public class Permission
    {
        public int PermissionId { get; set; } // Primary Key
        [Required, MaxLength(50)]
        public string PermissionName { get; set; } = default!; // e.g., "CreateCourse"
        public string? Description { get; set; } // Optional

        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
