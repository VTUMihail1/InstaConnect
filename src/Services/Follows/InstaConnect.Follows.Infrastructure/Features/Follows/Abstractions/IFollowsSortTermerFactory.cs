using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

internal interface IFollowsSortTermerFactory : ISortTermerFactory<FollowsSortTerm, IFollowsSortTermer, FollowResponse>;
