using InstaConnect.Follows.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

public interface IUserResponseFluentFactory
{
	public IUserResponseFluent Create(IAggregateFluent<UserResponse> fluent);
}
