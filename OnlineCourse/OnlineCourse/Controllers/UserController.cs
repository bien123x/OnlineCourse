using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCourse.DTOs;
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
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        // Yêu cầu xác thực để truy cập endpoint này
        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public async Task<ActionResult<ICollection<UserResponseDto>>> GetUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDto?>> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserResponseDto?>> AddUser(UserRequestDto userdto)
        {
            var newUser = await _userRepository.AddUser(userdto);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponseDto?>> UpdateUser(int id, [FromBody] UserRequestDto userdto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updatedUser = await _userRepository.UpdateUser(id, userdto);
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
