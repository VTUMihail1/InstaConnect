using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Filters;

public record PostCommentLikeFilteredCollectionReadQuery(
    string UserId,
    string UserName,
    string PostCommentId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : FilteredCollectionReadQuery<PostCommentLike>(pc => (string.IsNullOrEmpty(UserId) || pc.UserId.Equals(UserId)) &&
                                                         (string.IsNullOrEmpty(UserName) || pc.User!.UserName.StartsWith(UserName)) &&
                                                         (string.IsNullOrEmpty(PostCommentId) || pc.PostCommentId.Equals(PostCommentId)),
    SortOrder, SortPropertyName, Page, PageSize);
