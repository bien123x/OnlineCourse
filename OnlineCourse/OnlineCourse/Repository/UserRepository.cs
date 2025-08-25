using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.DTOs;
using OnlineCourse.Interface;
using OnlineCourse.Models;

namespace OnlineCourse.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> AddUser(UserRequestDto userdto)
        {
            var user = _mapper.Map<User>(userdto);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<UserResponseDto>> GetAllUsers()
        {
            var users = await _context.Users
                .Include(u => u.Role) // Include Role navigation property
                .ToListAsync();
            return _mapper.Map<ICollection<UserResponseDto>>(users);
        }

        public async Task<UserResponseDto?> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<UserResponseDto?> UpdateUser(int id, UserRequestDto userdto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            _mapper.Map(userdto, user);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
