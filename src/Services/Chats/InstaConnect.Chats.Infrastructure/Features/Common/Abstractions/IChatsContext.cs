using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Common.Abstractions;

public interface IChatsContext : IMongoDbContext
{
    public IMongoCollection<User> Users { get; }

    public IMongoCollection<Chat> Chats { get; }

    public IMongoCollection<ChatMessage> ChatMessages { get; }
}
