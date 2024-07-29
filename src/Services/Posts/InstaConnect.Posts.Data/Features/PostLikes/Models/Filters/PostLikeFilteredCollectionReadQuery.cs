using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Data.Features.PostLikes.Models.Filters;

public record PostLikeFilteredCollectionReadQuery(
    string UserId,
    string UserName,
    string PostId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
: FilteredCollectionReadQuery<PostLike>(pc => (string.IsNullOrEmpty(UserId) || pc.UserId == UserId) &&
                                               (string.IsNullOrEmpty(UserName) || pc.User!.UserName == UserName) &&
                                               (string.IsNullOrEmpty(PostId) || pc.PostId == PostId),
    SortOrder, SortPropertyName, Page, PageSize);
