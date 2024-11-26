using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;

public record PostCommentLikeCollectionReadQuery(
    string UserId,
    string UserName,
    string PostCommentId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
