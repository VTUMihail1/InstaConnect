using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Posts.Data.Features.PostComments.Models.Filters;

public record PostCommentCollectionReadQuery(
    string UserId,
    string UserName,
    string PostId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
