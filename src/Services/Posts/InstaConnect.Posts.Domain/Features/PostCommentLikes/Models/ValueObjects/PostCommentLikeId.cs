using InstaConnect.Common.Domain.Features.Entities.Abstractions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.ValueObjects;

public record PostCommentLikeId(PostCommentId CommentId, UserId UserId) : IEntityId;
