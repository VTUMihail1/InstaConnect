using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Models.Filters;
using InstaConnect.Shared.Data.Models.Enums;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetAllFilteredUsers;

public record GetAllUsersQuery(
    string UserName,
    string FirstName,
    string LastName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize) : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<UserPaginationQueryViewModel>;
