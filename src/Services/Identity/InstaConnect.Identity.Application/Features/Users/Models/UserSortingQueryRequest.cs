using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Application.Features.Users.Models;

public record UserSortingQueryRequest(
    CommonSortOrder Order,
    UserSortProperty Property);
