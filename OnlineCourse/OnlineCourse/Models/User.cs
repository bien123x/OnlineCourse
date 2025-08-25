using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string UserName { get; set; } = null!;

        [Required, MaxLength(200)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [MaxLength(200)]
        public string? FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Log> Logs { get; set; } = new List<Log>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}
