namespace OnlineCourse.DTOs
{
    public class PaymentRequestDto
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
