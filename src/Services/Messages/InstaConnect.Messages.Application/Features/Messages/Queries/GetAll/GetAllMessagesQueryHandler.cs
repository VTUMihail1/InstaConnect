using InstaConnect.Messages.Domain.Features.Messages.Models.Filters;

namespace InstaConnect.Messages.Application.Features.Messages.Queries.GetAll;

internal class GetAllMessagesQueryHandler : IQueryHandler<GetAllMessagesQuery, MessagePaginationQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IMessageReadRepository _messageReadRepository;

    public GetAllMessagesQueryHandler(
        IApplicationMapper applicationMapper,
        IMessageReadRepository messageReadRepository)
    {
        _applicationMapper = applicationMapper;
        _messageReadRepository = messageReadRepository;
    }

    public async Task<MessagePaginationQueryViewModel> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _applicationMapper.Map<MessageCollectionReadQuery>(request);

        var messages = await _messageReadRepository.GetAllAsync(filteredCollectionQuery, cancellationToken);
        var response = _applicationMapper.Map<MessagePaginationQueryViewModel>(messages);

        return response;
    }
}
