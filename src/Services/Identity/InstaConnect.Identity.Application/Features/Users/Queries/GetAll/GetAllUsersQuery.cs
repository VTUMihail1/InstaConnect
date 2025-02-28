using InstaConnect.Common.Application.Models.Filters;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

public record GetAllUsersQuery(
    string UserName,
    string FirstName,
    string LastName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize) : CollectionModel(SortOrder, SortPropertyName, Page, PageSize), IQuery<UserPaginationQueryViewModel>;
