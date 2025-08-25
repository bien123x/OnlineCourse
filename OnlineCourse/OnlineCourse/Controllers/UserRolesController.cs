using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Interface;
using OnlineCourse.Models;

namespace OnlineCourse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRolesController : Controller
    {
        private readonly IUserRolesRepository _userRolesRepository;
        public UserRolesController(IUserRolesRepository userRolesRepository)
        {
            _userRolesRepository = userRolesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Role>>> GetRolesForUser(int userId)
        {
            var roles = await _userRolesRepository.GetRolesForUser(userId);
            if (roles == null)
                return NotFound();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> AddRoleToUser(int userId, int roleId)
        {
            try
            {
                var role = await _userRolesRepository.AddRoleToUser(userId, roleId);
                if (role == null)
                    return NotFound("User or Role not found.");
                return CreatedAtAction(nameof(GetRolesForUser), new { userId = userId }, role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRoleFromUser(int userId, int roleId)
        {
            try
            {
                await _userRolesRepository.RemoveRoleFromUser(userId, roleId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
