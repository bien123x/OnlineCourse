namespace OnlineCourse.DTOs
{
    public class EnrollmentResponseDto
    {
        public int EnrollmentId { get; set; }
        public DateTime EnrolledAt { get; set; }
        public double Progress { get; set; }

        // Navigation
        public UserResponseDto? User { get; set; }
        public CourseResponseDto? Course { get; set; }
    }
}
