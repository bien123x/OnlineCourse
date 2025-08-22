using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

        public double Progress { get; set; } = 0;

        // FK -> User
        public int UserId { get; set; }
        public User? User { get; set; } = null;

        // FK -> Course
        public int CourseId { get; set; }
        public Course? Course { get; set; } = null;

    }
}