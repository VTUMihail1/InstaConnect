using InstaConnect.Common.Models.Enums;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

public record UserSortingQuery(
    SortOrder Order,
    UserSortProperty Property);
