using InstaConnect.Common.Application.Models;

namespace InstaConnect.Chats.Application.Features.Users.Commands.Update;

public record UpdateUserCommandRequest(
    UserIdPayload Id,
    string FirstName,
    string LastName,
    NamePayload Name,
    EmailPayload Email,
    ImagePayload? ProfileImage) : ICommandRequest<UpdateUserCommandResponse>;
