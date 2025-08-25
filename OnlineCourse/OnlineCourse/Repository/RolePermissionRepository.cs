using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.DTOs;
using OnlineCourse.Interface;
using OnlineCourse.Models;

namespace OnlineCourse.Repository
{
    public class RolePermissionRepository : IRolePermissionsRepository
    {
        private readonly AppDbContext _context;
        public RolePermissionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<RolePermission> AddPermissionToRole(int roleId, int permissionId)
        {
            var roleExists = await _context.Roles.AnyAsync(r => r.RoleId == roleId);

            if (!roleExists) return null;

            var permissionExists = await _context.Permissions.AnyAsync(p => p.PermissionId == permissionId);
            if (!permissionExists) return null;

            if (await _context.RolePermissions.AnyAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId))
                throw new Exception("Vai trò đã có quyền này.");

            var rolePermission = new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId
            };

            _context.RolePermissions.Add(rolePermission);
            await _context.SaveChangesAsync();

            return rolePermission;
        }

        public async Task<ICollection<PermissionDto>> GetPermissionsForRole(int roleId)
        {
            var roleExists = await _context.Roles.AnyAsync(r => r.RoleId == roleId);
            if (!roleExists) return null;

            var permissions = await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Join(_context.Permissions,
                      rp => rp.PermissionId,
                      p => p.PermissionId,
                      (rp, p) => new PermissionDto { PermissionName = p.PermissionName, Description = p.Description })
                .ToListAsync();

            return permissions;
        }

        public async Task RemovePermissionFromRole(int roleId, int permissionId)
        {
            var permission = await _context.RolePermissions
            .FirstOrDefaultAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);

            if (permission == null) throw new Exception("UserRole not found.");

            _context.RolePermissions.Remove(permission);
            await _context.SaveChangesAsync();
        }
    }
}
