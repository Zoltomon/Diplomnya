using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface;
using WebAPI.Classes.DTO;

namespace WebAPI.Controllers
{
    public class UserProfilePOSTController : Controller
    {
        private readonly IUserProfilePOST _IuserPost;
        public UserProfilePOSTController(IUserProfilePOST IuserPost) => _IuserPost = IuserPost;


        [HttpPost("createNote")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserProfileDTO>> Post(UserProfileDTO userDTO)
        {
            if (!_IuserPost.CreateNote(userDTO))
            {
                await Request.ReadFormAsync();
                return NotFound();
            }
            return Ok();
        }
    }
}
