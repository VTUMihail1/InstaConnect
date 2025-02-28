using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;

public record PostCommentCollectionReadQuery(
    string UserId,
    string UserName,
    string PostId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
