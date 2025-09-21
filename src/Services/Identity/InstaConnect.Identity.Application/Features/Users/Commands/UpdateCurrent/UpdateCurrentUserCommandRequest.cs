using Microsoft.AspNetCore.Http;

namespace InstaConnect.Users.Application.Features.Users.Commands.Update;

public record UpdateCurrentUserCommandRequest(
    string Id,
    string Email,
    string FirstName,
    string LastName,
    string Name,
    IFormFile? ProfileImage) : ICommandRequest<UpdateCurrentUserCommandResponse>;
