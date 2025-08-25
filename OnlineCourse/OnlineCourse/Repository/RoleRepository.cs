using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.DTOs;
using OnlineCourse.Interface;
using OnlineCourse.Models;

namespace OnlineCourse.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RoleRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Role> AddRole(string roleName)
        {
            var role = new Role { RoleName = roleName };
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

            if (await _context.UserRoles.AnyAsync(ur => ur.RoleId == id) ||
            await _context.RolePermissions.AnyAsync(rp => rp.RoleId == id))
                return false;

            _context.Roles.Remove(roleDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<RoleDto>> GetAllRoles()
        {
            return await _context.Roles
            .Select(r => new RoleDto { RoleId = r.RoleId, RoleName = r.RoleName })
            .ToListAsync();
        }

        public async Task<RoleDto?> GetRole(int id)
        {
            return await _context.Roles
            .Where(r => r.RoleId == id)
            .Select(r => new RoleDto { RoleId = r.RoleId, RoleName = r.RoleName })
            .FirstOrDefaultAsync();
        }

        public async Task<Role?> UpdateRole(int id, string roleName)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
                return null;

            role.RoleName = roleName;

            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }

    }
}
