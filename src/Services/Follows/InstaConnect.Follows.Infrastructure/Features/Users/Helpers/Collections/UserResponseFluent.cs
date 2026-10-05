using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Collections;

internal class UserResponseFluent :
	MongoDbResponseFluent<UserResponse>, IUserResponseFluent
{
	public UserResponseFluent(IAggregateFluent<UserResponse> fluent) : base(fluent)
	{
	}
}
