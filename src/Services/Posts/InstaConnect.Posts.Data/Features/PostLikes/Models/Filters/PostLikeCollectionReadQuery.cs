using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;

public record PostLikeCollectionReadQuery(
    string UserId,
    string UserName,
    string PostId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
