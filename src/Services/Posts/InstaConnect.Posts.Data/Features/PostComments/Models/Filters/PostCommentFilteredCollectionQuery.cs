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
: FilteredCollectionReadQuery<PostComment>(pc => (string.IsNullOrEmpty(UserId) || pc.UserId == UserId) &&
                                                  (string.IsNullOrEmpty(UserName) || pc.User!.UserName == UserName) &&
                                                  (string.IsNullOrEmpty(PostId) || pc.PostId == PostId),
    SortOrder, SortPropertyName, Page, PageSize);
