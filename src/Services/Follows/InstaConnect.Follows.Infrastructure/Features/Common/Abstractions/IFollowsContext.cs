using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Common.Abstractions;

public interface IFollowsContext : IMongoDbContext
{
	public IMongoCollection<User> Users { get; }

	public IMongoCollection<Follow> Follows { get; }
}
