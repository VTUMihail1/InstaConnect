using InstaConnect.Posts.Application.Features.Users.Models;

namespace InstaConnect.Posts.Application.Features.PostLikes.Models;

public record PostLikeIdPayload(PostIdPayload Id, UserIdPayload UserId);
