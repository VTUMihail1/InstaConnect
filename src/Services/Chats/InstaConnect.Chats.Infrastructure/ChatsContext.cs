using InstaConnect.Chats.Infrastructure.Utilities;
using InstaConnect.Common.Infrastructure;

using MongoDB.Driver;

namespace InstaConnect.Chats.Infrastructure;

public class ChatsContext : MongoDbContext, IChatsContext
{
    public ChatsContext(IMongoClient mongoClient, IMongoDatabase mongoDatabase)
        : base(mongoClient, mongoDatabase)
    {
    }

    public IMongoCollection<User> Users => ToCollection<User, UserId>(ChatsCollectionNames.Users);

    public IMongoCollection<Chat> Chats => ToCollection<Chat, ChatId>(ChatsCollectionNames.Chats);

    public IMongoCollection<ChatMessage> ChatMessages => ToCollection<ChatMessage, ChatMessageId>(ChatsCollectionNames.ChatMessages);
}
