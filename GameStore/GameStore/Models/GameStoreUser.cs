using Microsoft.AspNetCore.Identity;

namespace GameStore.Models
{
    public class GameStoreUser : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateSignUp { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
