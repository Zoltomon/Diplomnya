using WebAPI.Classes.DTO;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Classes.AutoReg
{
    public class RegistrationClass:IUserProfilePOST
    {
        private readonly ZdorzhyievSwebContext _context;
        public RegistrationClass(ZdorzhyievSwebContext context)
        {
            _context = context;
        }
        public bool CreateNote(UserProfileDTO userDTO)
        {
            try
            {
                string hashPass = BCrypt.Net.BCrypt.HashPassword(userDTO.UserPassword);
                if (hashPass != null)
                {
                    var createUser = new Models.UserProfile
                    {
                        Login = userDTO.UserLogin,
                        Password = hashPass,
                        Email = userDTO.UserEmail,
                        Telephone = userDTO.UserTelephone,
                        RoleId = 1,
                        StatusId = 1
                    };

                    _context.UserProfiles.Add(createUser);
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Results.BadRequest(ex);
                throw;
            }
        }

    }
}
