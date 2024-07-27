using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Data.Models.Filters.Posts;

public record PostFilteredCollectionReadQuery(
    string UserId,
    string UserName,
    string Title,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
: FilteredCollectionReadQuery<Post>(pc => (string.IsNullOrEmpty(UserId) || pc.UserId == UserId) &&
                                          (string.IsNullOrEmpty(UserName) || pc.User!.UserName == UserName) &&
                                          (string.IsNullOrEmpty(Title) || pc.Title == Title),
    SortOrder, SortPropertyName, Page, PageSize);
