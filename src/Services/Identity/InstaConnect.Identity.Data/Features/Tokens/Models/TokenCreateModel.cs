using System.Security.Claims;

namespace InstaConnect.Identity.Data.Features.Tokens.Models;

public record TokenCreateModel(ICollection<Claim> Claims);
