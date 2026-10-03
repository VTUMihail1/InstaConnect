using InstaConnect.Chats.Domain.Features.Users.Models.Responses;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

public interface IUserResponseFluentFactory
{
	public IUserResponseFluent Create(IAggregateFluent<UserResponse> fluent);
}
