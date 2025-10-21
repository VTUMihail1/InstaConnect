using InstaConnect.Common.Infrastructure;
using InstaConnect.ChatCommentLikes.Domain.Features.ChatCommentLikes.Models.Entities;
using InstaConnect.ChatComments.Domain.Features.ChatComments.Models.Entities;
using InstaConnect.ChatLikes.Domain.Features.ChatLikes.Models.Entities;
using InstaConnect.Chats.Infrastructure.Abstractions;
using InstaConnect.Chats.Infrastructure.Utilities;

using MongoDB.Driver;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;

namespace InstaConnect.Chats.Infrastructure;
public class ChatsContext : MongoDbContext, IChatsContext
{
    public ChatsContext(IMongoClient mongoClient, IMongoDatabase mongoDatabase)
        : base(mongoClient, mongoDatabase)
    {
    }

    public IMongoCollection<User> Users => Collection<User>(ChatCollectionNames.Users);

    public IMongoCollection<Chat> Chats => Collection<Chat>(ChatCollectionNames.Chats);

    public IMongoCollection<ChatMessage> ChatMessages => Collection<ChatMessage>(ChatCollectionNames.ChatMessages);
}
