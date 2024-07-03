using System.Security.Claims;

namespace InstaConnect.Identity.Data.Models;

public class CreateAccessTokenModel
{
    public string UserId { get; set; } = string.Empty;

    public ICollection<Claim> Claims { get; set; } = [];
}


