using InstaConnect.Shared.Data.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Users.Data.Models.Entities;

public class UserRole : IdentityUserRole<string>, IBaseEntity
{
    public UserRole() : base()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
