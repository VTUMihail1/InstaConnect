using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Add;

public record AddUserCommandRequest(
    string Name,
    string Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage) : ICommandRequest<AddUserCommandResponse>;
