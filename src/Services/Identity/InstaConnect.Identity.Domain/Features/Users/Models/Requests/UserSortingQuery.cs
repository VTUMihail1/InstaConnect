using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UserSortingQuery(
    SortOrder Order,
    UserSortProperty Property);
