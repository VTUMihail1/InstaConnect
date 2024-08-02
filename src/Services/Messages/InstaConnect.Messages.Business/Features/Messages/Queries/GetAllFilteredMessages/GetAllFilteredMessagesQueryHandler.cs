using InstaConnect.Messages.Business.Features.Messages.Models;
using InstaConnect.Messages.Data.Features.Messages.Abstractions;
using InstaConnect.Messages.Data.Features.Messages.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Features.Messages.Queries.GetAllFilteredMessages;

internal class GetAllFilteredMessagesQueryHandler : IQueryHandler<GetAllFilteredMessagesQuery, MessagePaginationQueryViewModel>
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

    public async Task<MessagePaginationQueryViewModel> Handle(GetAllFilteredMessagesQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<MessageFilteredCollectionReadQuery>(request);

        var messages = await _messageReadRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<MessagePaginationQueryViewModel>(messages);

        return response;
    }
}
