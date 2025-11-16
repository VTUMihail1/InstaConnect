using InstaConnect.Common.Application.Models;
using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Models;

public record PostQueryFilter(
    UserIdPayload UserId,
    NamePayload UserName,
    string Title);
