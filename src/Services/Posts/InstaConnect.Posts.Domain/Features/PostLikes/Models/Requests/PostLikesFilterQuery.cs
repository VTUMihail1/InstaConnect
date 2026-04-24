using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

public record PostLikesFilterQuery(
    PostId Id,
    Name UserName);
