using OnlineCourse.DTOs;
using OnlineCourse.Models;

namespace OnlineCourse.Interface
{
    public interface IUserRepository
    {
        Task<ICollection<UserResponseDto>> GetAllUsers();
        Task<UserResponseDto> AddUser(UserRequestDto userdto);
        Task<UserResponseDto?> GetUser(int id);
        Task<UserResponseDto?> UpdateUser(int id, UserRequestDto userdto);
        Task<bool> DeleteUser(int id);

    }
}
