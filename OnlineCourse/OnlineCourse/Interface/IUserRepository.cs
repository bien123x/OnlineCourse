using OnlineCourse.Models;

namespace OnlineCourse.Interface
{
    public interface IUserRepository
    {
        ICollection<User> GetAllUsers();
        User AddUser(User user);
    }
}
