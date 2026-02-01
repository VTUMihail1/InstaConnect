namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
internal interface IChatCollectionFactory
{
    ChatCollection Create(ICollection<Chat> chats, int totalCount, CommonPaginationQuery pagination);
}
