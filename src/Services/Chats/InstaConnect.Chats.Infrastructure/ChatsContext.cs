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

    public IMongoCollection<User> Users => ToCollection<User, UserId>(ChatCollectionNames.Users);

    public IMongoCollection<Chat> Chats => ToCollection<Chat, ChatId>(ChatCollectionNames.Chats);

    public IMongoCollection<ChatMessage> ChatMessages => ToCollection<ChatMessage, ChatMessageId>(ChatCollectionNames.ChatMessages);
}
