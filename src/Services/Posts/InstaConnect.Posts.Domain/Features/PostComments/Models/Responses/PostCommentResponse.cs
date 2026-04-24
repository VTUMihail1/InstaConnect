using InstaConnect.Common.Domain.Features.Entities.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Responses;

public record PostCommentResponse(
        PostCommentId Id,
        UserId UserId,
        string Content,
        UserResponse? User,
        PostResponse? Post,
        bool IsLikedByCurrentUser,
        DateTimeOffset CreatedAtUtc,
        DateTimeOffset UpdatedAtUtc) : IEntityResponse;
