using OnlineCourse.Models;

namespace OnlineCourse.Interface
{
    public interface IRoleRepository
    {
        Task<ICollection<Role>> GetAllRoles();
        Task<Role> AddRole(Role role);
        Task<Role?> GetRole(int id);
        Task<Role?> UpdateRole(Role role);
        Task<bool> DeleteRole(int id);
    }
}
