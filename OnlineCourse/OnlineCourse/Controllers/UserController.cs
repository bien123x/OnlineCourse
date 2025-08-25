using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.Interface;
using OnlineCourse.Models;
using OnlineCourse.Repository;

namespace OnlineCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // Yêu cầu xác thực để truy cập endpoint này
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<ICollection<User>>> GetUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User?>> AddUser([FromBody] User user)
        {
            var newUser = await _userRepository.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User?>> UpdateUser(int id, User user)
        {
            if (id != user.UserId)
                return BadRequest("User ID mismatch");
            var updatedUser = await _userRepository.UpdateUser(user);
            if (updatedUser == null)
                return NotFound();
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var deleted = await _userRepository.DeleteUser(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
