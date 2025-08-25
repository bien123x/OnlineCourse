using OnlineCourse.DTOs;
using OnlineCourse.Models;

namespace OnlineCourse.Interface
{
    public interface IRolePermissionsRepository
    {
        Task<ICollection<PermissionDto>> GetPermissionsForRole(int roleId);
        Task<RolePermission> AddPermissionToRole(int roleId, int permissionId);
        Task RemovePermissionFromRole(int roleId, int permissionId);
    }
}
