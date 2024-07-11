using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Messages.Write.Business.Commands.Messages.DeleteMessage;

internal class DeleteMessageCommandHandler : ICommandHandler<DeleteMessageCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;
    private readonly IMessageRepository _messageRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public DeleteMessageCommandHandler(
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

    public async Task Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
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

        _messageRepository.Delete(existingMessage);

        var messageDeletedEvent = _instaConnectMapper.Map<MessageDeletedEvent>(existingMessage);
        await _eventPublisher.Publish(messageDeletedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
