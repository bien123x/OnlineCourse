using OnlineCourse.DTOs;
using OnlineCourse.Models;

namespace OnlineCourse.Interface
{
    public interface IPermissionRepository
    {
        Task<ICollection<PermissionDto>> GetAllPremissions();
        Task<Permission> AddPermission(PermissionDto perDto);
        Task<PermissionDto?> GetPermission(int id);
        Task UpdatePermission(int id, PermissionDto perDto);
        Task DeletePermission(int id);
    }
}
