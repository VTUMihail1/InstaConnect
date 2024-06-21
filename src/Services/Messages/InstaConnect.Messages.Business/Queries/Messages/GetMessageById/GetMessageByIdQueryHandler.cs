using AutoMapper;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Message;

namespace InstaConnect.Messages.Business.Queries.Messages.GetMessageById;

internal class GetMessageByIdQueryHandler : IQueryHandler<GetMessageByIdQuery, MessageViewModel>
{
    private readonly IMapper _mapper;
    private readonly IMessageRepository _messageRepository;

    public GetMessageByIdQueryHandler(
        IMapper mapper,
        IMessageRepository messageRepository)
    {
        _mapper = mapper;
        _messageRepository = messageRepository;
    }

    public async Task<MessageViewModel> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
    {
        var message = await _messageRepository.GetByIdAsync(request.Id, cancellationToken);

        if (message == null)
        {
            throw new MessageNotFoundException();
        }

        var response = _mapper.Map<MessageViewModel>(message);

        return response;
    }
}
