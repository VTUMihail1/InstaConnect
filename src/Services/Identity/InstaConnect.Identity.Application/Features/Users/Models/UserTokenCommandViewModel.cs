namespace InstaConnect.Identity.Application.Features.Users.Models;

public record UserTokenCommandViewModel(string Value, DateTime ValidUntil);
