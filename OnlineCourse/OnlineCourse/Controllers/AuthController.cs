using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineCourse.Data;
using OnlineCourse.Interface;
using OnlineCourse.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        private readonly AppDbContext _context;

        public AuthController(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == login.Username && u.Password == login.Password);
            if (user != null)
            {
                // Lấy danh sách Role của User từ UserRole
                var userRoles = await _context.UserRoles
                    .Where(ur => ur.UserId == user.UserId)
                    .Select(ur => ur.RoleId)
                    .ToListAsync();

                // Lấy danh sách Permission từ các Role của User
                var permissions = await _context.RolePermissions
                    .Where(rp => userRoles.Contains(rp.RoleId))
                    .Join(_context.Permissions,
                          rp => rp.PermissionId,
                          p => p.PermissionId,
                          (rp, p) => p.PermissionName)
                    .Distinct() // Loại bỏ quyền trùng lặp nếu user có nhiều role
                    .ToListAsync();

                // Tạo token
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                // Thêm Role vào claims
                var roles = await _context.UserRoles
                    .Where(ur => ur.UserId == user.UserId)
                    .Join(_context.Roles,
                          ur => ur.RoleId,
                          r => r.RoleId,
                          (ur, r) => r.RoleName)
                    .ToListAsync();
                // Thêm Role vào claims
                claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
                // Thêm Permission vào claims
                claims.AddRange(permissions.Select(p => new Claim("Permission", p)));

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30), // Token hết hạn sau 30 phút
                    signingCredentials: credentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { token = tokenString });
            }

            return Unauthorized("Sai tên đăng nhập hoặc mật khẩu.");
        }
    }
}
