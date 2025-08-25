using OnlineCourse.Models;

namespace OnlineCourse.Interface
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsers();
        Task<User> AddUser(User user);
        Task<User?> GetUser(int id);
        Task<User?> UpdateUser(User user);
        Task<bool> DeleteUser(int id);

    }
}
