using InstaConnect.Chats.Domain.Features.Users.Models.Responses;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Collections;

public class UserResponseFluent :
	MongoDbResponseFluent<UserResponse>, IUserResponseFluent
{
	public UserResponseFluent(IAggregateFluent<UserResponse> fluent) : base(fluent)
	{
	}
}
