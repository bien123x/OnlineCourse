using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCourse.Models
{
    [NotMapped]
    public class LoginModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
