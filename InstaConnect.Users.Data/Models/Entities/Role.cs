using InstaConnect.Shared.Data.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Users.Data.Models.Entities
{
    public class Role : IdentityRole, IBaseEntity
    {
        public Role() : base() { }

        public Role(string role) : base(role) { }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
