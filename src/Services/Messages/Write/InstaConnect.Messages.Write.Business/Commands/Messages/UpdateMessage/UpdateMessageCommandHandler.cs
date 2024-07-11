using InstaConnect.Messages.Write.Business.Models;
using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;

internal class UpdateMessageCommandHandler : ICommandHandler<UpdateMessageCommand, MessageViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;
    private readonly IMessageRepository _messageRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public UpdateMessageCommandHandler(
        IUnitOfWork unitOfWork,
        IEventPublisher eventPublisher,
        IMessageRepository messageRepository,
        IInstaConnectMapper instaConnectMapper)
    {
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
        _messageRepository = messageRepository;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task<MessageViewModel> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        var existingMessage = await _messageRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingMessage == null)
        {
            throw new MessageNotFoundException();
        }

        if (request.CurrentUserId != existingMessage.SenderId)
        {
            throw new AccountForbiddenException();
        }

        _instaConnectMapper.Map(request, existingMessage);
        _messageRepository.Update(existingMessage);

        var messageUpdatedEvent = _instaConnectMapper.Map<MessageUpdatedEvent>(existingMessage);
        await _eventPublisher.Publish(messageUpdatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var messageViewModel = _instaConnectMapper.Map<MessageViewModel>(existingMessage);

        return messageViewModel;
    }
}
