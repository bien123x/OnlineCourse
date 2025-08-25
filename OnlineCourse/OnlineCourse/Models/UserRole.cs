namespace OnlineCourse.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; } // Primary Key
        public int UserId { get; set; }
        public User? User { get; set; } // Navigation property
        public int RoleId { get; set; }
        public Role? Role { get; set; } // Navigation property
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    }
}
