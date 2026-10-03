using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowsSortTermer : ISortTermer<FollowsSortTerm, FollowResponse>;
