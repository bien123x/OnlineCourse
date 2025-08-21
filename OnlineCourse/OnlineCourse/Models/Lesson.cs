using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Models
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = null!;

        public string? Content { get; set; }
        public string? VideoUrl { get; set; }
        public string? MaterialUrl { get; set; }
        public int OrderIndex { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // FK -> Course
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        [InverseProperty("Lessons")]
        public Course Course { get; set; } = null!;
    }
}
