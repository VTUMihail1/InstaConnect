namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.ValueObjects;

public record PostLikeId(PostId Id, UserId UserId) : IEntityId;
