using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatCollection : IMongoDbCollection<Chat>
{
	public IChatFluent AggregateFluent();

	public Task DeleteAsync(
		Chat entity,
		CancellationToken cancellationToken);
}
