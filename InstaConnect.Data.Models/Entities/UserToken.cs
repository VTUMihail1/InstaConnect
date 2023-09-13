using InstaConnect.Data.Models.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Data.Models.Entities
{
    public class UserToken : IdentityUserToken<string>, IBaseEntity
    {
        public UserToken() : base() { }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
