using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Data.Features.Posts.Models.Filters;

public record PostFilteredCollectionReadQuery(
    string UserId,
    string UserName,
    string Title,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
: FilteredCollectionReadQuery<Post>(pc => (string.IsNullOrEmpty(UserId) || pc.UserId.Equals(UserId)) &&
                                          (string.IsNullOrEmpty(UserName) || pc.User!.UserName.Equals(UserName)) &&
                                          (string.IsNullOrEmpty(Title) || pc.Title.StartsWith(Title)),
    SortOrder, SortPropertyName, Page, PageSize);
