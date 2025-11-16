using InstaConnect.Common.Application.Models;
using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeUserQueryResponse(UserIdPayload Id, NamePayload Name, ImagePayload? ProfileImage);
