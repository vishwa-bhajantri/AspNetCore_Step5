using Project_Step5.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Project_Step5.Services;
using Project_Step5.Models;

namespace Project_Step5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            List<User> users = _userService.GetUsers();

            return Ok(users);
        }
    }
}
