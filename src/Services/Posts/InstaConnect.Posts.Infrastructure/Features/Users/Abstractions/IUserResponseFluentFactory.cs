using InstaConnect.Posts.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Abstractions;

public interface IUserResponseFluentFactory
{
	public IUserResponseFluent Create(IAggregateFluent<UserResponse> fluent);
}
