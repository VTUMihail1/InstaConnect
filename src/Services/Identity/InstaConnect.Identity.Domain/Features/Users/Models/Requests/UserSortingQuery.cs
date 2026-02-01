using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UserSortingQuery(
    CommonSortOrder Order,
    UserSortProperty Term) : ISortingQuery<UserSortProperty>;
