using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;
using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Helpers.Collections;

public class UserResponseFluent :
	MongoDbResponseFluent<UserResponse>, IUserResponseFluent
{
	public UserResponseFluent(IAggregateFluent<UserResponse> fluent) : base(fluent)
	{
	}
}
