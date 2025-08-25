using OnlineCourse.DTOs;
using OnlineCourse.Models;
using OnlineCourse.Repository;

namespace OnlineCourse.Interface
{
    public interface IRoleRepository
    {
        Task<ICollection<RoleDto>> GetAllRoles();
        Task<Role> AddRole(string roleName);
        Task<RoleDto?> GetRole(int id);
        Task<Role?> UpdateRole(int id, string roleName);
        Task<bool> DeleteRole(int id);
    }
}
