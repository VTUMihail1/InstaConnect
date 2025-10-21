using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Responses;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
internal interface IChatCollectionFactory
{
    ChatCollection Create(ICollection<Chat> chats, int totalCount, ChatPaginationQuery pagination);
}
