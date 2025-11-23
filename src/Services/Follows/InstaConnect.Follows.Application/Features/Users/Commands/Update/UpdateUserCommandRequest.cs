using InstaConnect.Common.Application.Models;
using InstaConnect.Follows.Application.Features.Users.Models;

namespace InstaConnect.Follows.Application.Features.Users.Commands.Update;

public record UpdateUserCommandRequest(
    UserIdPayload Id,
    string FirstName,
    string LastName,
    NamePayload Name,
    EmailPayload Email,
    ImagePayload? ProfileImage) : ICommandRequest<UpdateUserCommandResponse>;
