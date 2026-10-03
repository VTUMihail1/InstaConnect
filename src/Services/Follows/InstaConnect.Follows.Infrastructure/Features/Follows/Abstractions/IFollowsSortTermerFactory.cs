using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowsSortTermerFactory : ISortTermerFactory<FollowsSortTerm, IFollowsSortTermer, FollowResponse>;
