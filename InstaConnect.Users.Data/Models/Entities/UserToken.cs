using InstaConnect.Data.Models.Entities.Base;
using InstaConnect.Shared.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Data.Models.Entities
{
    public class UserToken : IdentityUserToken<string>, IBaseEntity
    {
        public UserToken() : base()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
