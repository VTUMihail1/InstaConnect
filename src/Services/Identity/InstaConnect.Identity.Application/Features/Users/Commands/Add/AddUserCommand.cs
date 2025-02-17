using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Add;

public record AddUserCommand(
    string UserName,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage) : ICommand<UserCommandViewModel>;
