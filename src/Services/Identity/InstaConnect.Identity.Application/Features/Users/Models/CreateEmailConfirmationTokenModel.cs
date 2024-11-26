namespace InstaConnect.Identity.Application.Features.Users.Models;

public record CreateEmailConfirmationTokenModel(string UserId, string Email);
