using InstaConnect.Identity.Business.Models;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Identity.Business.Queries.User.GetAllFilteredUsers;

public record GetAllFilteredUsersQuery(
    string UserName, 
    string FirstName, 
    string LastName, 
    SortOrder SortOrder, 
    string SortPropertyName, 
    int Page, 
    int PageSize) : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<UserPaginationQueryViewModel>;
