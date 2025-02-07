namespace InstaConnect.Identity.Application.Features.Users.Models;

public record CreateForgotPasswordTokenModel(string UserId, string Email);
