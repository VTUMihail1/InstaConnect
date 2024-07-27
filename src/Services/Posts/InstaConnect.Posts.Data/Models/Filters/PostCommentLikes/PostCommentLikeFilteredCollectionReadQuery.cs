using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Data.Models.Filters.PostCommentLikes;

public record PostCommentLikeFilteredCollectionReadQuery(
    string UserId, 
    string UserName, 
    string PostCommentId, 
    SortOrder SortOrder, 
    string SortPropertyName, 
    int Page, 
    int PageSize)
    : FilteredCollectionReadQuery<PostCommentLike>(pc => (string.IsNullOrEmpty(UserId) || pc.UserId == UserId) &&
                                                         (string.IsNullOrEmpty(UserName) || pc.User!.UserName == UserName) &&
                                                         (string.IsNullOrEmpty(PostCommentId) || pc.PostCommentId == PostCommentId),
    SortOrder, SortPropertyName, Page, PageSize);
