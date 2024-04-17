using InstaConnect.Shared.Data.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Users.Data.Models.Entities
{
    public class User : IdentityUser, IBaseEntity
    {
        public User() : base() { }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<Token> Tokens { get; set; } = new List<Token>();
    }
}


