using System.Security.Claims;

namespace InstaConnect.Users.Business.Models;

public class CreateAccessTokenModel
{
    public string UserId { get; set; }

    public ICollection<Claim> Claims { get; set; } = new List<Claim>();
}


