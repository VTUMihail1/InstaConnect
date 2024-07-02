using AutoMapper;
using InstaConnect.Messages.Business.Write.Abstract;
using InstaConnect.Messages.Business.Write.Models;
using InstaConnect.Messages.Data.Write.Abstractions;
using InstaConnect.Messages.Data.Write.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Business.Write.Commands.Messages.AddMessage;

internal class AddMessageCommandHandler : ICommandHandler<AddMessageCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageSender _messageSender;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMessageRepository _messageRepository;
    private readonly IRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddMessageCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IMessageSender messageSender,
        IPublishEndpoint publishEndpoint,
        IMessageRepository messageRepository,
        IRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _messageSender = messageSender;
        _publishEndpoint = publishEndpoint;
        _messageRepository = messageRepository;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task Handle(AddMessageCommand request, CancellationToken cancellationToken)
    {
        var messageGetUserByIdModel = _mapper.Map<MessageGetUserByIdModel>(request);

        var getUserBySenderIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(
            messageGetUserByIdModel.GetUserBySenderIdRequest,
            cancellationToken);

        if (getUserBySenderIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var getUserByReceiverIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(
            messageGetUserByIdModel.GetUserByReceiverIdRequest,
            cancellationToken);

        if (getUserByReceiverIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var message = _mapper.Map<Message>(request);
        _messageRepository.Add(message);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var messageCreatedEvent = _mapper.Map<MessageCreatedEvent>(message);
        await _publishEndpoint.Publish(messageCreatedEvent, cancellationToken);

        var sendMessageDTO = _mapper.Map<SendMessageModel>(request);
        await _messageSender.SendMessageToUserAsync(sendMessageDTO);

    }
}
