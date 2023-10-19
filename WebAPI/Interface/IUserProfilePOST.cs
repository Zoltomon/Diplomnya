using WebAPI.Classes.DTO;

namespace WebAPI.Interface
{
    public interface IUserProfilePOST
    {
        public bool CreateNote(UserProfileDTO userDTO);
    }
}
