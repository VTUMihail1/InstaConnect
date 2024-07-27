using System.Security.Claims;

namespace InstaConnect.Identity.Data.Models;

public record TokenCreateModel(ICollection<Claim> Claims);
