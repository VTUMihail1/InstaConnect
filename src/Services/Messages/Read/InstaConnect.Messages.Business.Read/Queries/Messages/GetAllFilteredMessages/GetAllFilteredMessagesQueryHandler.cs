using AutoMapper;
using InstaConnect.Messages.Business.Read.Models;
using InstaConnect.Messages.Data.Read.Abstractions;
using InstaConnect.Messages.Data.Read.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Messages.Business.Read.Queries.Messages.GetAllFilteredMessages;

internal class GetAllFilteredMessagesQueryHandler : IQueryHandler<GetAllFilteredMessagesQuery, ICollection<MessageViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IMessageRepository _messageRepository;

    public GetAllFilteredMessagesQueryHandler(
        IMapper mapper,
        IMessageRepository messageRepository)
    {
        _mapper = mapper;
        _messageRepository = messageRepository;
    }

    public async Task<ICollection<MessageViewModel>> Handle(GetAllFilteredMessagesQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<MessageFilteredCollectionQuery>(request);

        var messages = await _messageRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<MessageViewModel>>(messages);

        return response;
    }
}
