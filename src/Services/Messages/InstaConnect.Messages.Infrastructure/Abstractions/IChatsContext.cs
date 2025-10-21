using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Abstractions;
public interface IChatsContext : IMongoDbContext
{
    public IMongoCollection<User> Users { get; }

    public IMongoCollection<Chat> Chats { get; }

    public IMongoCollection<ChatMessage> ChatMessages { get; }
}
