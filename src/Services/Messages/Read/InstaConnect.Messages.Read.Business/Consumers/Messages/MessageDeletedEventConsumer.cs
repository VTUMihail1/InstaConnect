using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Read.Business.Consumers.Messages;

internal class MessageDeletedEventConsumer : IConsumer<MessageDeletedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageRepository _messageRepository;

    public MessageDeletedEventConsumer(
        IUnitOfWork unitOfWork, IMessageRepository messageRepository)
    {
        _unitOfWork = unitOfWork;
        _messageRepository = messageRepository;
    }

    public async Task Consume(ConsumeContext<MessageDeletedEvent> context)
    {
        var existingMessage = await _messageRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingMessage == null)
        {
            return;
        }

        _messageRepository.Delete(existingMessage);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
