using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluderFactory
	: IIncluderFactory<FollowsIncludeType, FollowsDestinationType, FollowsIncludeDescriptor, IUserIncluder, User>;
