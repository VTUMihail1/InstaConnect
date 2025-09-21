using Microsoft.AspNetCore.Http;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record AddUserCommand(
    string Name,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage);
