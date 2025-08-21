using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }

        [Required, MaxLength(100)]
        public string Action { get; set; } = null!;

        public string? Details { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // FK -> User
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Logs")]
        public User User { get; set; } = null!;
    }
}
