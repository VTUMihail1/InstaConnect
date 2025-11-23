using InstaConnect.Common.Application.Models;

namespace InstaConnect.Chats.Application.Features.Users.Models;

public record UserQueryResponse(UserIdPayload Id, NamePayload Name, ImagePayload? ProfileImage);
