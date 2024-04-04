using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.UserTOs;
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
        public ActionResult<UserDTO> GetUserById(string userId)
        {
            var user = _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpPost()]
        public ActionResult<LoginResponseModel> Signup(PostUserDTO user)
        {
            var addedUser = _userService.Signup(user);
            return Ok(addedUser);
        }

        [HttpPost("login")]
        public ActionResult<LoginResponseModel> Login(UserLoginDTO request)
        {
            var loggedUser = _userService.Login(request);
            return Ok(loggedUser);
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
