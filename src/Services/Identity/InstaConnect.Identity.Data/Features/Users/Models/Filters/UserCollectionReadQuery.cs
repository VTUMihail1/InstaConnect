using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Identity.Data.Features.Users.Models.Filters;

public record UserCollectionReadQuery(
    string UserName,
    string FirstName,
    string LastName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize)
    : CollectionReadQuery<User>(u => (string.IsNullOrEmpty(UserName) || u.UserName.StartsWith(UserName)) &&
                                             (string.IsNullOrEmpty(FirstName) || u.FirstName.StartsWith(FirstName)) &&
                                             (string.IsNullOrEmpty(LastName) || u.LastName.StartsWith(LastName)),
                                        SortOrder, SortPropertyName, Page, PageSize);
