using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Filters;

public record PostCommentLikeCollectionReadQuery(
    string UserId,
    string UserName,
    string PostCommentId,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionReadQuery<PostCommentLike>(pc => (string.IsNullOrEmpty(UserId) || pc.UserId == UserId) &&
                                                         (string.IsNullOrEmpty(UserName) || pc.User!.UserName.StartsWith(UserName)) &&
                                                         (string.IsNullOrEmpty(PostCommentId) || pc.PostCommentId == PostCommentId),
    SortOrder, SortPropertyName, Page, PageSize);
