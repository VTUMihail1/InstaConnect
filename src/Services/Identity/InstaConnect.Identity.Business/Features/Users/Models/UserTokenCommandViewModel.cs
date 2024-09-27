namespace InstaConnect.Identity.Business.Features.Users.Models;

public record UserTokenCommandViewModel(string Value, DateTime ValidUntil);
