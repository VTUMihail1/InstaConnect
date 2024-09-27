using InstaConnect.Messages.Data.Features.Messages.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Messages.Business.Features.Messages.Commands.DeleteMessage;

internal class DeleteMessageCommandHandler : ICommandHandler<DeleteMessageCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageWriteRepository _messageWriteRepository;

    public DeleteMessageCommandHandler(
        IUnitOfWork unitOfWork,
        IMessageWriteRepository messageWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _messageWriteRepository = messageWriteRepository;
    }

    public async Task Handle(
        DeleteMessageCommand request,
        CancellationToken cancellationToken)
    {
        var existingMessage = await _messageWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingMessage == null)
        {
            throw new MessageNotFoundException();
        }

        if (request.CurrentUserId != existingMessage.SenderId)
        {
            throw new UserForbiddenException();
        }

        _messageWriteRepository.Delete(existingMessage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
