using AutoMapper;
using InstaConnect.Messages.Read.Data.Abstractions;
using InstaConnect.Messages.Read.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Read.Business.Consumers.Messages;

internal class MessageCreatedEventConsumer : IConsumer<MessageCreatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageRepository _messageRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;

    public MessageCreatedEventConsumer(
        IUnitOfWork unitOfWork,
        IMessageRepository messageRepository,
        IInstaConnectMapper instaConnectMapper)
    {
        _unitOfWork = unitOfWork;
        _messageRepository = messageRepository;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task Consume(ConsumeContext<MessageCreatedEvent> context)
    {
        var existingMessage = await _messageRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingMessage != null)
        {
            return;
        }

        var message = _instaConnectMapper.Map<Message>(context.Message);
        _messageRepository.Add(message);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
