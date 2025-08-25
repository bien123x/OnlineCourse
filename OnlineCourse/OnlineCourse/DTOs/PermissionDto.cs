using System.ComponentModel.DataAnnotations;

namespace OnlineCourse.DTOs
{
    public class PermissionDto
    {
        public string PermissionName { get; set; } = default!;
        public string? Description { get; set; } 
    }
}
