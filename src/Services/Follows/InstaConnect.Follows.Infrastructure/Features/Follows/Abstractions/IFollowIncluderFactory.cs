using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

internal interface IFollowIncluderFactory
	: IIncluderFactory<FollowsIncludeType, FollowsDestinationType, FollowsIncludeDescriptor, IFollowIncluder, Follow>;

