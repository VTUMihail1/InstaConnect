using InstaConnect.Common.Application.Models;
using InstaConnect.Follows.Application.Features.Users.Models;

namespace InstaConnect.Follows.Application.Features.Users.Commands.Add;

public record AddUserCommandRequest(
    UserIdPayload Id,
    string FirstName,
    string LastName,
    NamePayload Name,
    EmailPayload Email,
    ImagePayload? ProfileImage) : ICommandRequest<AddUserCommandResponse>;
