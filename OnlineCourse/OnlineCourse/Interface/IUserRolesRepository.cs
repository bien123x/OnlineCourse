using OnlineCourse.Models;

namespace OnlineCourse.Interface
{
    public interface IUserRolesRepository
    {
        Task<ICollection<Role>> GetRolesForUser(int userId);
        Task<Role> AddRoleToUser(int userId, int roleId);
        Task RemoveRoleFromUser(int userId, int roleId);
    }
}
