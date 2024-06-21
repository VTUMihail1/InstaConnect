﻿using AutoMapper;
using InstaConnect.Messages.Business.Abstract;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.Models.Users;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Business.Commands.Messages.AddMessage;

internal class AddMessageCommandHandler : ICommandHandler<AddMessageCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageSender _messageSender;
    private readonly IMessageRepository _messageRepository;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddMessageCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IMessageSender messageSender, 
        IMessageRepository messageRepository,
        ICurrentUserContext currentUserContext,
        IRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _messageSender = messageSender;
        _messageRepository = messageRepository;
        _currentUserContext = currentUserContext;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task Handle(AddMessageCommand request, CancellationToken cancellationToken)
    {
        var getCurrentUserRequest = _mapper.Map<GetUserByIdRequest>(request);
        var getCurrentUserResponse = await _getUserByIdRequestClient.GetResponse<CurrentUserDetails>(getCurrentUserRequest, cancellationToken);

        if(getCurrentUserResponse.Message == null)
        {
            throw new UserNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        var message = _mapper.Map<Message>(request);
        _mapper.Map(currentUserDetails, message);
        _messageRepository.Add(message);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var sendMessageDTO = _mapper.Map<SendMessageModel>(request);
        await _messageSender.SendMessageToUserAsync(sendMessageDTO);

    }
}
