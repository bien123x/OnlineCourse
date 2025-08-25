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
        public async Task<Role> AddRole(RoleDto roledto)
        {
            var role = _mapper.Map<Role>(roledto);
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

        public async Task<Role?> UpdateRole(int id, RoleDto roledto)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
                return null;

            _mapper.Map(roledto, role);
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }

    }
}
