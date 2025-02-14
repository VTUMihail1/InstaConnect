using InstaConnect.Messages.Application.Features.Messages.Models;
using InstaConnect.Messages.Domain.Features.Messages.Abstractions;
using InstaConnect.Messages.Domain.Features.Messages.Models.Filters;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;

namespace InstaConnect.Messages.Application.Features.Messages.Queries.GetAll;

internal class GetAllMessagesQueryHandler : IQueryHandler<GetAllMessagesQuery, MessagePaginationQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IMessageReadRepository _messageReadRepository;

    public GetAllMessagesQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IMessageReadRepository messageReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _messageReadRepository = messageReadRepository;
    }

    public async Task<MessagePaginationQueryViewModel> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _instaConnectMapper.Map<MessageCollectionReadQuery>(request);

        var messages = await _messageReadRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);
        var response = _instaConnectMapper.Map<MessagePaginationQueryViewModel>(messages);

        return response;
    }
}
