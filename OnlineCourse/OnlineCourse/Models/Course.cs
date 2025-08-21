using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsPublished { get; set; } = false;

        // FK -> User (Teacher)
        public int TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        [InverseProperty("CoursesTaught")]
        public User Teacher { get; set; } = null!;

        // Navigation
        [InverseProperty("Course")]
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

        [InverseProperty("Course")]
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        [InverseProperty("Course")]
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
