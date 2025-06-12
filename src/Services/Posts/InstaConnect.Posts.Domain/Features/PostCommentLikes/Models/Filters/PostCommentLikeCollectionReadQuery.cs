using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Filters;

public record PostCommentLikeCollectionReadQuery(
    string UserId,
    string UserName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
