using WebAPI.Classes.DTO;
using WebAPI.Classes.HelperClass;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Classes.AutoReg
{
    public class AutoRegClass:IUserProfile
    {
        private readonly ZdorzhyievSwebContext _context;
        public AutoRegClass(ZdorzhyievSwebContext context)
        {
            _context = context;
        }
        public List<UserProfileDTO> FirstOfDefault(string Login, string Password)
        {
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

            if (data != null)
            {
                return data;
            }
            else
            {
                return new List<UserProfileDTO>() { };
            }
        }
    }
}
