using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [MaxLength(50)]
        public string PaymentMethod { get; set; } = null!;

        [MaxLength(50)]
        public string Status { get; set; } = "Pending";

        // FK -> User
        public int UserId { get; set; }
        public User? User { get; set; } = null;

        // FK -> Course
        public int CourseId { get; set; }
        public Course? Course { get; set; } = null;

    }
}
