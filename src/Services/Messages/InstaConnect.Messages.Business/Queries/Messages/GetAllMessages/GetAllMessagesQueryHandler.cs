using AutoMapper;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Messages.Business.Queries.Messages.GetAllMessages;

internal class GetAllMessagesQueryHandler : IQueryHandler<GetAllMessagesQuery, ICollection<MessageViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IMessageRepository _messageRepository;

    public GetAllMessagesQueryHandler(
        IMapper mapper,
        IMessageRepository messageRepository)
    {
        _mapper = mapper;
        _messageRepository = messageRepository;
    }

    public async Task<ICollection<MessageViewModel>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionQuery>(request);

        var messages = await _messageRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<MessageViewModel>>(messages);

        return response;
    }
}
