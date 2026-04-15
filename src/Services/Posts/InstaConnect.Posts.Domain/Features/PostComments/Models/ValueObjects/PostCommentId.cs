namespace InstaConnect.Posts.Domain.Features.PostComments.Models.ValueObjects;

public record PostCommentId(PostId Id, string CommentId) : IEntityId;
