using AutoMapper;
using InstaConnect.Messages.Write.Business.Abstract;
using InstaConnect.Messages.Write.Business.Models;
using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Messages.Write.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Write.Business.Commands.Messages.AddMessage;

internal class AddMessageCommandHandler : ICommandHandler<AddMessageCommand, MessageViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageSender _messageSender;
    private readonly IEventPublisher _eventPublisher;
    private readonly IMessageRepository _messageRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddMessageCommandHandler(
        IUnitOfWork unitOfWork,
        IMessageSender messageSender,
        IEventPublisher eventPublisher,
        IMessageRepository messageRepository,
        IInstaConnectMapper instaConnectMapper,
        IInstaConnectRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _unitOfWork = unitOfWork;
        _messageSender = messageSender;
        _eventPublisher = eventPublisher;
        _messageRepository = messageRepository;
        _instaConnectMapper = instaConnectMapper;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task<MessageViewModel> Handle(AddMessageCommand request, CancellationToken cancellationToken)
    {
        var messageGetUserByIdModel = _instaConnectMapper.Map<MessageGetUserByIdModel>(request);

        var getUserBySenderIdResponse = await _getUserByIdRequestClient.GetResponseMessageAsync<GetUserByIdResponse>(
            messageGetUserByIdModel.GetUserBySenderIdRequest,
            cancellationToken);

        if (getUserBySenderIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var getUserByReceiverIdResponse = await _getUserByIdRequestClient.GetResponseMessageAsync<GetUserByIdResponse>(
            messageGetUserByIdModel.GetUserByReceiverIdRequest,
            cancellationToken);

        if (getUserByReceiverIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var message = _instaConnectMapper.Map<Message>(request);
        _messageRepository.Add(message);

        var messageCreatedEvent = _instaConnectMapper.Map<MessageCreatedEvent>(message);
        await _eventPublisher.PublishAsync(messageCreatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var messageSendModel = _instaConnectMapper.Map<MessageSendModel>(message);
        await _messageSender.SendMessageToUserAsync(messageSendModel, cancellationToken);

        var messageViewModel = _instaConnectMapper.Map<MessageViewModel>(message);
        
        return messageViewModel;
    }
}
