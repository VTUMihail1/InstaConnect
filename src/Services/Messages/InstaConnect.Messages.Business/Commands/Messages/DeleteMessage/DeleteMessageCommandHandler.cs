using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;

internal class DeleteMessageCommandHandler : ICommandHandler<DeleteMessageCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageWriteRepository _messageRepository;

    public DeleteMessageCommandHandler(
        IUnitOfWork unitOfWork,
        IMessageWriteRepository messageRepository)
    {
        _unitOfWork = unitOfWork;
        _messageRepository = messageRepository;
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

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
