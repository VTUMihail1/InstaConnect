using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Requests;

public record UsersSortingQuery(
    CommonSortOrder Order,
    UsersSortTerm Term) : ISortingQuery<UsersSortTerm>;
