using WebAPI.Classes.DTO;

namespace WebAPI.Interface
{
    public interface IUserProfilePOST
    {
        public List<UserProfileDTO> FirstOfDefault(string login, string password, string email, string telephone);
    }
}
