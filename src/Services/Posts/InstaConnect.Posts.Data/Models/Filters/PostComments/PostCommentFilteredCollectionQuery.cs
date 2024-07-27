using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Data.Models.Filters.PostComments;

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
