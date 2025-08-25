using Microsoft.AspNetCore.Mvc;
using OnlineCourse.DTOs;
using OnlineCourse.Interface;
using OnlineCourse.Models;

namespace OnlineCourse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<Role>>> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role?>> GetRole(int id)
        {
            var role = await _roleRepository.GetRole(id);
            if (role == null)
                return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role?>> AddRole([FromBody] RoleDto roledto)
        {
            var newRole = await _roleRepository.AddRole(roledto);
            return CreatedAtAction(nameof(GetRole), new { id = newRole.RoleId }, newRole);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Role?>> UpdateRole(int id, RoleDto roledto)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);
            var updatedRole = await _roleRepository.UpdateRole(id, roledto);
            if (updatedRole == null)
                return NotFound();
            return Ok(updatedRole);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleById(int id)
        {
            var deleted = await _roleRepository.DeleteRole(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
