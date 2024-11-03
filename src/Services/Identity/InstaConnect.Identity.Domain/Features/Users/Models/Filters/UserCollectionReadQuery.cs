using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Identity.Data.Features.Users.Models.Filters;

public record UserCollectionReadQuery(
    string UserName,
    string FirstName,
    string LastName,
    SortOrder SortOrder,
    string SortPropertyName,
    int Page,
    int PageSize);
