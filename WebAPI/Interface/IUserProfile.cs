using WebAPI.Classes.DTO;

namespace WebAPI.Interface
{
    public interface IUserProfile
    {
        public List<UserProfileDTO> FirstOfDefault(string login, string password);
    }
}
