﻿using AutoMapper;
using InstaConnect.Messages.Data.Read.Abstractions;
using InstaConnect.Messages.Data.Read.Models.Entities;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Business.Read.Consumers.Messages;

internal class MessageCreatedEventConsumer : IConsumer<MessageCreatedEvent>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageRepository _messageRepository;

    public MessageCreatedEventConsumer(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IMessageRepository messageRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _messageRepository = messageRepository;
    }

    public async Task Consume(ConsumeContext<MessageCreatedEvent> context)
    {
        var message = _mapper.Map<Message>(context.Message);
        _messageRepository.Add(message);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
