using System.Linq.Expressions;
using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Models.Enums;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Identity.Data.Models.Filters;

public record UserFilteredCollectionReadQuery(
    string UserName, 
    string FirstName, 
    string LastName, 
    SortOrder SortOrder, 
    string SortPropertyName, 
    int Page, 
    int PageSize)
    : FilteredCollectionReadQuery<User>(u => (string.IsNullOrEmpty(UserName) || u.UserName.StartsWith(UserName, StringComparison.InvariantCultureIgnoreCase)) &&
                                             (string.IsNullOrEmpty(FirstName) || u.FirstName.StartsWith(FirstName, StringComparison.InvariantCultureIgnoreCase)) &&
                                             (string.IsNullOrEmpty(LastName) || u.LastName.StartsWith(LastName, StringComparison.InvariantCultureIgnoreCase)), 
                                        SortOrder, SortPropertyName, Page, PageSize);
