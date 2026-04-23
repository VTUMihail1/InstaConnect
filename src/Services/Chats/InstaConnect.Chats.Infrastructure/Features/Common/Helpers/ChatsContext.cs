using InstaConnect.Chats.Infrastructure.Features.Common.Abstractions;
using InstaConnect.Chats.Infrastructure.Features.Common.Utilities;
using InstaConnect.Common.Infrastructure;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure.Features.Common.Helpers;

internal class ChatsContext : MongoDbContext, IChatsContext
{
    public ChatsContext(IMongoClient mongoClient, IMongoDatabase mongoDatabase)
        : base(mongoClient, mongoDatabase)
    {
    }

    public IMongoCollection<User> Users => ToCollection<User, UserId>(ChatsCollectionNames.Users);

    public IMongoCollection<Chat> Chats => ToCollection<Chat, ChatId>(ChatsCollectionNames.Chats);

    public IMongoCollection<ChatMessage> ChatMessages => ToCollection<ChatMessage, ChatMessageId>(ChatsCollectionNames.ChatMessages);
}
