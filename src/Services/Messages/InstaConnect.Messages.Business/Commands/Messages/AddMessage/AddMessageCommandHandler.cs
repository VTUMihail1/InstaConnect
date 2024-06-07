using AutoMapper;
using InstaConnect.Messages.Business.Abstract.Helpers;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Abstractions.Repositories;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Messages.Business.Commands.Messages.AddMessage;

internal class AddMessageCommandHandler : ICommandHandler<AddMessageCommand>
{
    private readonly IMapper _mapper;
    private readonly IMessageSender _messageSender;
    private readonly IMessageRepository _messageRepository;
    private readonly IRequestClient<GetCurrentUserRequest> _getCurrentUserRequestClient;
    private readonly IRequestClient<ValidateUserByIdRequest> _validateUserByIdRequestClient;

    public AddMessageCommandHandler(
        IMapper mapper, 
        IMessageSender messageSender, 
        IMessageRepository messageRepository, 
        IRequestClient<GetCurrentUserRequest> getCurrentUserRequestClient, 
        IRequestClient<ValidateUserByIdRequest> validateUserByIdRequestClient)
    {
        _mapper = mapper;
        _messageSender = messageSender;
        _messageRepository = messageRepository;
        _getCurrentUserRequestClient = getCurrentUserRequestClient;
        _validateUserByIdRequestClient = validateUserByIdRequestClient;
    }

    public async Task Handle(AddMessageCommand request, CancellationToken cancellationToken)
    {
        var getCurrentUserRequest = _mapper.Map<GetCurrentUserRequest>(request);
        var getCurrentUserResponse = await _getCurrentUserRequestClient.GetResponse<CurrentUserDetails>(getCurrentUserRequest, cancellationToken);

        var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(request);
        await _validateUserByIdRequestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

        var message = _mapper.Map<Message>(request);
        _mapper.Map(getCurrentUserResponse.Message, message);
        await _messageRepository.AddAsync(message, cancellationToken);

        var sendMessageDTO = _mapper.Map<SendMessageDTO>(request);
        await _messageSender.SendMessageToUserAsync(sendMessageDTO);
    }
}
