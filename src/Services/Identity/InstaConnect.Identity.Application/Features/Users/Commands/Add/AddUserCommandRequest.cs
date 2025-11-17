using InstaConnect.Common.Application.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Application.Features.Users.Commands.Add;

public record AddUserCommandRequest(
    NamePayload Name,
    EmailPayload Email,
    string Password,
    string ConfirmPassword,
    string FirstName,
    string LastName,
    IFormFile? ProfileImage) : ICommandRequest<AddUserCommandResponse>;
