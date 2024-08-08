using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Data.Features.PostComments.Models.Filters;

public record PostCommentCollectionReadQuery(
    string UserId,
    string UserName,
    string PostId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
: CollectionReadQuery<PostComment>(pc => (string.IsNullOrEmpty(UserId) || pc.UserId == UserId) &&
                                                  (string.IsNullOrEmpty(UserName) || pc.User!.UserName.StartsWith(UserName)) &&
                                                  (string.IsNullOrEmpty(PostId) || pc.PostId == PostId),
    SortOrder, SortPropertyName, Page, PageSize);
