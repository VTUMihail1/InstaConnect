using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Domain.Features.Messaging.Models;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowsSortingQuery(
    CommonSortOrder Order,
    FollowsSortTerm Term) : ISortingQuery<FollowsSortTerm>;
