using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Classes.DTO;
using WebAPI.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserProfile _users;
        private readonly IUserProfilePOST _usersPost;
        public UserController(IUserProfile users, IUserProfilePOST usersPost)
        {
            _users = users;
            _usersPost = usersPost;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserProfileDTO>>> Get(string UserLogin, string UserPassword) => await Task.FromResult(_users.FirstOfDefault(UserLogin, UserPassword));

        public async Task<ActionResult<List<UserProfileDTO>>> Get(string UserLogin, string UserPassword, string UserTelephone, string UserEmail) =>
            await Task.FromResult(_usersPost.FirstOfDefault(UserLogin, UserPassword, UserTelephone, UserEmail));
    }
}
