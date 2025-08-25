using Microsoft.AspNetCore.Mvc;
using OnlineCourse.DTOs;
using OnlineCourse.Interface;

namespace OnlineCourse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : Controller
    {
        private readonly IPermissionRepository permissionRepository;
        public PermissionController(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPermissions()
        {
            var permissions = await permissionRepository.GetAllPremissions();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPermission(int id)
        {
            var permission = await permissionRepository.GetPermission(id);
            if (permission == null)
                return NotFound();
            return Ok(permission);
        }

        [HttpPost]
        public async Task<ActionResult> AddPermission(PermissionDto perDto)
        {
            var newPermission = await permissionRepository.AddPermission(perDto);
            return CreatedAtAction(nameof(GetPermission), new { id = newPermission.PermissionId }, newPermission);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePermission(int id, PermissionDto perDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await permissionRepository.UpdatePermission(id, perDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissionById(int id)
        {
            try
            {
                await permissionRepository.DeletePermission(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            return NoContent();
        }
    }
}