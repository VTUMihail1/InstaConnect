using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;

internal class GetAllFilteredMessagesQueryHandler : IQueryHandler<GetAllFilteredMessagesQuery, MessagePaginationCollectionModel>
{
    private readonly IMessageReadRepository _messageRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public GetAllFilteredMessagesQueryHandler(
        IMessageReadRepository messageRepository,
        IInstaConnectMapper instaConnectMapper)
    {
        _messageRepository = messageRepository;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task<MessagePaginationCollectionModel> Handle(GetAllFilteredMessagesQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<MessageFilteredCollectionReadQuery>(request);

        var messages = await _messageRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<MessagePaginationCollectionModel>(messages);

        return response;
    }
}
