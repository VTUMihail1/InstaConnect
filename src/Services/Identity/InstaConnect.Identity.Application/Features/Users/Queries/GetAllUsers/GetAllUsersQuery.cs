using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Models.Filters;
using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAllUsers;

public record GetAllUsersQuery(
    string UserName,
    string FirstName,
    string LastName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize) : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<UserPaginationQueryViewModel>;
