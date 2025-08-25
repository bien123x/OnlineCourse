namespace OnlineCourse.DTOs
{
    public class CourseResponseDto
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPublished { get; set; }

        // Navigation
        public UserResponseDto? Teacher { get; set; }
        public ICollection<LessonDto>? Lessons { get; set; }
    }
}
