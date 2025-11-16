using InstaConnect.Common.Application.Models;
using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

public record PostCommentLikeUserQueryResponse(UserIdPayload Id, NamePayload Name, ImagePayload? ProfileImage);
