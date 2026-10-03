using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Helpers.Collections;

public class UserResponseFluentFactory : IUserResponseFluentFactory
{
	public IUserResponseFluent Create(IAggregateFluent<UserResponse> fluent)
	{
		return new UserResponseFluent(fluent);
	}
}
