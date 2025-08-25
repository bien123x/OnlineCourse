namespace OnlineCourse.DTOs
{
    public class CourseRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public decimal Price { get; set; }
        public bool IsPublished { get; set; }
    }
}
