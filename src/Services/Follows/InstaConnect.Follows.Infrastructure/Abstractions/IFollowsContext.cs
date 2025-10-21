using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Abstractions;
public interface IFollowsContext : IMongoDbContext
{
    public IMongoCollection<User> Users { get; }

    public IMongoCollection<Follow> Follows { get; }
}
