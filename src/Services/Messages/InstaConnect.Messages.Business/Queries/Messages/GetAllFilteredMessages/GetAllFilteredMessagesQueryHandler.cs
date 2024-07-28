using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Queries.Messages.GetAllFilteredMessages;

internal class GetAllFilteredMessagesQueryHandler : IQueryHandler<GetAllFilteredMessagesQuery, MessagePaginationCollectionModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IMessageReadRepository _messageReadRepository;

    public GetAllFilteredMessagesQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IMessageReadRepository messageReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _messageReadRepository = messageReadRepository;
    }

    public async Task<MessagePaginationCollectionModel> Handle(GetAllFilteredMessagesQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<MessageFilteredCollectionReadQuery>(request);

        var messages = await _messageReadRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<MessagePaginationCollectionModel>(messages);

        return response;
    }
}
