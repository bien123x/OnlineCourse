using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Interface;

namespace OnlineCourse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolePermissionsController : Controller
    {
        private readonly IRolePermissionsRepository _rolePermissionsRepository;
        public RolePermissionsController(IRolePermissionsRepository rolePermissionsRepository)
        {
            _rolePermissionsRepository = rolePermissionsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPermissionsForRole(int roleId)
        {
            var permissions = await _rolePermissionsRepository.GetPermissionsForRole(roleId);
            if (permissions == null)
                return NotFound();
            return Ok(permissions);
        }

        [HttpPost]
        public async Task<ActionResult> AddPermissionToRole(int roleId, int permissionId)
        {
            try
            {
                var rolePermission = await _rolePermissionsRepository.AddPermissionToRole(roleId, permissionId);
                if (rolePermission == null)
                    return NotFound("Role or Permission not found.");
                return CreatedAtAction(nameof(GetPermissionsForRole), new { roleId = roleId }, rolePermission);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePermissionFromRole(int roleId, int permissionId)
        {
            try
            {
                await _rolePermissionsRepository.RemovePermissionFromRole(roleId, permissionId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}