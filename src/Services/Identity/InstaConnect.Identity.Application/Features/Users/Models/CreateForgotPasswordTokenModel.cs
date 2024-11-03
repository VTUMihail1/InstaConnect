namespace InstaConnect.Identity.Business.Features.Users.Models;

public record CreateForgotPasswordTokenModel(string UserId, string Email);
