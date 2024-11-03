namespace InstaConnect.Identity.Business.Features.Users.Models;

public record CreateEmailConfirmationTokenModel(string UserId, string Email);
