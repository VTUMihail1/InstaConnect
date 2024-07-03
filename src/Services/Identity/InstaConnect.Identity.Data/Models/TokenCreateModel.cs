using System.Security.Claims;

namespace InstaConnect.Identity.Data.Models;
public class TokenCreateModel
{
    public ICollection<Claim> Claims { get; set; } = [];
}
