namespace InstaConnect.Identity.Business.Features.Accounts.Models;

public record CreateEmailConfirmationTokenModel(string UserId, string Email);
