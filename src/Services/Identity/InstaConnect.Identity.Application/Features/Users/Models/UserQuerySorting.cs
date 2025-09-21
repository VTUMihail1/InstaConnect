using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Users.Domain.Features.Users.Models;

public record UserQuerySorting(
    SortOrder Order,
    UserSortProperty Property);
