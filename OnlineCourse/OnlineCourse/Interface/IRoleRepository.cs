using OnlineCourse.DTOs;
using OnlineCourse.Models;
using OnlineCourse.Repository;

namespace OnlineCourse.Interface
{
    public interface IRoleRepository
    {
        Task<ICollection<Role>> GetAllRoles();
        Task<Role> AddRole(RoleDto roledto);
        Task<Role?> GetRole(int id);
        Task<Role?> UpdateRole(int id, RoleDto roledto);
        Task<bool> DeleteRole(int id);
    }
}
