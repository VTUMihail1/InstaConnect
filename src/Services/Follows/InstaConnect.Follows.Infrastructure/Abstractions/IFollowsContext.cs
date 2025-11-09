using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Abstractions;
public interface IFollowsContext : IMongoDbContext
{
    public IMongoCollection<User> Users { get; }

    public IMongoCollection<Follow> Follows { get; }
}
