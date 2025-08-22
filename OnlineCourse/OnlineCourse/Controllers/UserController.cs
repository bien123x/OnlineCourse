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
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            var users = _userRepository.GetAllUsers();
            return Ok( users );
        }
    }
}
