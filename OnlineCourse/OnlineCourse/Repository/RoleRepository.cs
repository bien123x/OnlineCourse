using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Interface;
using OnlineCourse.Models;

namespace OnlineCourse.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Role> AddRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var roleDelete = await _context.Roles.FindAsync(id);
            if (roleDelete == null)
            {
                return false;
            }
            _context.Roles.Remove(roleDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            return role;
        }

        public async Task<Role?> UpdateRole(Role role)
        {
            var newRole = await _context.Roles.FindAsync(role.RoleId);
            if (newRole == null)
                return null;

            newRole.RoleName = role.RoleName;
            _context.Roles.Update(newRole);
            await _context.SaveChangesAsync();
            return newRole;
        }

    }
}
