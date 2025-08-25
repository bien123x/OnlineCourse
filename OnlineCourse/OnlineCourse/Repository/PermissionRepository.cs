using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.DTOs;
using OnlineCourse.Interface;
using OnlineCourse.Models;
using System.Security;

namespace OnlineCourse.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PermissionRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Permission> AddPermission(PermissionDto perDto)
        {
            var per = _mapper.Map<PermissionDto, Permission>(perDto);

            await _context.Permissions.AddAsync(per);
            await _context.SaveChangesAsync();
            return per;
        }

        public async Task DeletePermission(int id)
        {
            var perDelete = _context.Permissions.Find(id);
            if (perDelete == null) throw new KeyNotFoundException("Permission not found");
            if (await _context.RolePermissions.AnyAsync(rp => rp.PermissionId == id))
                throw new InvalidOperationException("Cannot delete permission assigned to roles");

            _context.Permissions.Remove(perDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<PermissionDto>> GetAllPremissions()
        {
            return await _context.Permissions
                .Select(p => new PermissionDto { PermissionName = p.PermissionName, Description = p.Description })
                .ToListAsync();
        }

        public async Task<PermissionDto?> GetPermission(int id)
        {
            var per = await _context.Permissions.FindAsync(id);

            if (per == null) return null;

            return _mapper.Map<PermissionDto>(per);
        }

        public async Task UpdatePermission(int id, PermissionDto perDto)
        {
            var per = await _context.Permissions.FindAsync(id);

            if (per == null) throw new KeyNotFoundException("Permission not found");

            _mapper.Map(perDto, per);

            _context.Permissions.Update(per);
            await _context.SaveChangesAsync();
        }
    }
}
