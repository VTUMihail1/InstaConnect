using AutoMapper;
using InstaConnect.Messages.Read.Business.Models;
using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;

namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetMessageById;

internal class GetMessageByIdQueryHandler : IQueryHandler<GetMessageByIdQuery, MessageViewModel>
{
    private readonly IMessageRepository _messageRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public GetMessageByIdQueryHandler(
        IMessageRepository messageRepository, 
        IInstaConnectMapper instaConnectMapper)
    {
        _messageRepository = messageRepository;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task<MessageViewModel> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
    {
        var message = await _messageRepository.GetByIdAsync(request.Id, cancellationToken);

        if (message == null)
        {
            throw new MessageNotFoundException();
        }

        if (message.SenderId != request.CurrentUserId)
        {
            throw new AccountForbiddenException();
        }

        var response = _instaConnectMapper.Map<MessageViewModel>(message);

        return response;
    }
}
