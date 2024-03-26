using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs;
using UniforBackend.Domain.Models.Entities;

namespace UniforBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public ActionResult<User> GetUserById(string userId)
        {
            var user = _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpPost()]
        public ActionResult<User> AddUser(PostUserDTO user)
        {
            var addedUser = _userService.AddUser(user);
            return Ok(addedUser);
        }

        [HttpPut("{userId}")]
        public ActionResult<UserDTO> UpdateUser(UpdateUserDTO updatedUser, string userId)
        {
            var _updatedUser = _userService.UpdateUser(updatedUser, userId);
            return Ok(_updatedUser);
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(string userId)
        {
            _userService.DeleteUser(userId);
            return Ok("User deletado com sucesso!");
        }
    }
}
