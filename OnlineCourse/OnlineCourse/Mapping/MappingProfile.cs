using AutoMapper;
using OnlineCourse.DTOs;
using OnlineCourse.Models;

namespace OnlineCourse.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add your mappings here
            // CreateMap<Source, Destination>();
            // User
            CreateMap<User, UserResponseDto>();
            //CreateMap<UserRequestDto, User>()
            //    .ForMember(dest => dest.Password, opt => opt.Ignore()); // hash ở service
            CreateMap<UserRequestDto, User>();

            // Role
            CreateMap<Role, RoleDto>();

            // Course
            CreateMap<Course, CourseResponseDto>()
                .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher))
                .ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Lessons));
            CreateMap<CourseRequestDto, Course>();

            // Lesson
            CreateMap<Lesson, LessonDto>();
            CreateMap<LessonDto, Lesson>();

            // Enrollment
            CreateMap<Enrollment, EnrollmentResponseDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course));
            CreateMap<EnrollmentRequestDto, Enrollment>();

            // Payment
            CreateMap<Payment, PaymentResponseDto>();
            CreateMap<PaymentRequestDto, Payment>();

            // Log
            CreateMap<Log, LogResponseDto>();
        }
    }
}
