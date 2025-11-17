using InstaConnect.Common.Application.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Identity.Application.Features.Users.Commands.UpdateCurrent;

public record UpdateCurrentUserCommandRequest(
    UserIdPayload Id,
    EmailPayload Email,
    string FirstName,
    string LastName,
    NamePayload Name,
    IFormFile? ProfileImage) : ICommandRequest<UpdateCurrentUserCommandResponse>;
