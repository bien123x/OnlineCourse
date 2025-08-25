namespace OnlineCourse.DTOs
{
    public class UserRequestDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // client gửi plain password
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; }
    }
}
