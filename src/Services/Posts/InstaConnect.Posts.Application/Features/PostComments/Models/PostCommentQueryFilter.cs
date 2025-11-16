using InstaConnect.Common.Application.Models;
using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.PostComments.Models;

public record PostCommentQueryFilter(
    PostIdPayload Id,
    UserIdPayload UserId,
    NamePayload UserName);
