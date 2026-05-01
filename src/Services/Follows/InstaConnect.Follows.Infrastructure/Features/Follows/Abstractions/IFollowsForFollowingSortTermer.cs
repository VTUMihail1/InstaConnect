using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

internal interface IFollowsForFollowingSortTermer : ISortTermer<FollowsForFollowingSortTerm, FollowResponse>;
