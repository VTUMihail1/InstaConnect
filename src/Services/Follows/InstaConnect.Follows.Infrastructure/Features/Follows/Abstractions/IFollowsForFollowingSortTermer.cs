using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

internal interface IFollowsForFollowingSortTermer : ISortTermer<FollowsForFollowingSortTerm, FollowResponse>;
