using InstaConnect.Common.Application.Models;

namespace InstaConnect.Chats.Application.Features.Users.Commands.Add;

public record AddUserCommandRequest(
    UserIdPayload Id,
    string FirstName,
    string LastName,
    NamePayload Name,
    EmailPayload Email,
    ImagePayload? ProfileImage) : ICommandRequest<AddUserCommandResponse>;
