using WebAPI.Models;

namespace WebAPI.Classes.DTO
{
    public class UserProfileDTO
    {
        public string? UserLogin { get; set; }

        public string? UserPassword { get; set; }

        public string? UserEmail { get; set; }

        public string? UserTelephone { get; set; }

        public string? UserStatus { get; set; }

        public string? UserRole { get; set; }
    }
}
