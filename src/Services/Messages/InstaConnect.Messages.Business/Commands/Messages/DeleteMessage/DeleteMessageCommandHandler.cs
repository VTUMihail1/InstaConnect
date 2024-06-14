﻿using AutoMapper;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;

internal class DeleteMessageCommandHandler : ICommandHandler<DeleteMessageCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageRepository _messageRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public DeleteMessageCommandHandler(
        IUnitOfWork unitOfWork,
        IMessageRepository messageRepository,
        ICurrentUserContext currentUserContext)
    {
        _unitOfWork = unitOfWork;
        _messageRepository = messageRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
    {
        var existingMessage = await _messageRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingMessage == null)
        {
            throw new MessageNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        if (currentUserDetails.Id != existingMessage.SenderId)
        {
            throw new AccountForbiddenException();
        }

        _messageRepository.Delete(existingMessage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
