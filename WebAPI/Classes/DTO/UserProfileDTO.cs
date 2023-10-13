using WebAPI.Models;

namespace WebAPI.Classes.DTO
{
    public class UserProfileDTO
    {
        public int UserId { get; set; }

        public string? UserLogin { get; set; }

        public string? UserPassword { get; set; }

        public string? UserEmail { get; set; }

        public string? UserTelephone { get; set; }

        public int? UserStatusId { get; set; }

        public int? UserRoleId { get; set; }
    }
}
