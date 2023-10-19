using BCrypt.Net;
using WebAPI.Classes.DTO;
using WebAPI.Classes.HelperClass;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Classes.AutoReg
{
    public class AutorizationClass:IUserProfile
    {
        private readonly ZdorzhyievSwebContext _context;
        public AutorizationClass(ZdorzhyievSwebContext context)
        {
            _context = context;
        }
        public List<UserProfileDTO> FirstOfDefault(string Login, string Password)
        {
            var userProfile = _context.UserProfiles.FirstOrDefault(u => u.Login == Login);

            if (userProfile != null && BCrypt.Net.BCrypt.Verify(Password, userProfile.Password)) {
                List<UserProfileDTO> data = _context.UserProfiles.Select(
                            x => new UserProfileDTO
                            {
                                UserLogin = x.Login,
                                UserPassword = x.Password,
                                UserRole = x.Role.Name,
                                UserStatus = x.Status.Name,
                                UserEmail = x.Email,
                                UserTelephone = x.Telephone,
                            }
                    ).Where(u => u.UserLogin == Login && u.UserPassword == Password).ToList();
                return data;
            }
            else
            {
                return new List<UserProfileDTO>() { };
            }
        }
    }
}
