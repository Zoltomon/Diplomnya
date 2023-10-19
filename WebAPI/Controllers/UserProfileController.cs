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
        public UserController(IUserProfile users)
        {
            _users = users;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserProfileDTO>>> Get(string UserLogin, string UserPassword) => await Task.FromResult(_users.FirstOfDefault(UserLogin, UserPassword));
    }
}
