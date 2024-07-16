using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Read.Business.Consumers.Messages;

internal class MessageUpdatedEventConsumer : IConsumer<MessageUpdatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageRepository _messageRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public MessageUpdatedEventConsumer(
        IUnitOfWork unitOfWork, 
        IMessageRepository messageRepository,
        IInstaConnectMapper instaConnectMapper)
    {
        _unitOfWork = unitOfWork;
        _messageRepository = messageRepository;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task Consume(ConsumeContext<MessageUpdatedEvent> context)
    {
        var existingMessage = await _messageRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingMessage == null)
        {
            return;
        }

        _instaConnectMapper.Map(context.Message, existingMessage);
        _messageRepository.Update(existingMessage);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
