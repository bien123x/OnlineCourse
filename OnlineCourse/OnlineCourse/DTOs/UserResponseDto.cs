namespace OnlineCourse.DTOs
{
    public class UserResponseDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        //public string Password { get; set; } = string.Empty; // hashed password
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        // Navigation
        public RoleDto? Role { get; set; }
    }
}
