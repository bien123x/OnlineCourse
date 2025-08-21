using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string UserName { get; set; } = null!;

        [Required, MaxLength(200)]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        [MaxLength(200)]
        public string? FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        // FK -> Role
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("Users")]
        public Role Role { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        // Navigation
        [InverseProperty("Teacher")]
        public ICollection<Course> CoursesTaught { get; set; } = new List<Course>();

        [InverseProperty("User")]
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        [InverseProperty("User")]
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

        [InverseProperty("User")]
        public ICollection<Log> Logs { get; set; } = new List<Log>();
    }
}
