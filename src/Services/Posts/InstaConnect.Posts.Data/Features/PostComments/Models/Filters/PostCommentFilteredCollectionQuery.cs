using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Data.Features.PostComments.Models.Filters;

public record PostCommentFilteredCollectionReadQuery(
    string UserId,
    string UserName,
    string PostId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
: FilteredCollectionReadQuery<PostComment>(pc => (string.IsNullOrEmpty(UserId) || pc.UserId.Equals(UserId)) &&
                                                  (string.IsNullOrEmpty(UserName) || pc.User!.UserName.Equals(UserName)) &&
                                                  (string.IsNullOrEmpty(PostId) || pc.PostId.Equals(PostId)),
    SortOrder, SortPropertyName, Page, PageSize);
