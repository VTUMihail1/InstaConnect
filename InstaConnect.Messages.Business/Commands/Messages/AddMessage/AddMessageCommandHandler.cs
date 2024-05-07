using AutoMapper;
using InstaConnect.Data.Models.Entities;
using InstaConnect.Messages.Business.Abstract.Helpers;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Abstractions.Repositories;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Business.RequestClients;

namespace InstaConnect.Messages.Business.Commands.PostComments.AddPostComment;

public class AddMessageCommandHandler : ICommandHandler<AddMessageCommand>
{
    private readonly IMapper _mapper;
    private readonly IMessageSender _messageSender;
    private readonly IMessageRepository _messageRepository;
    private readonly IValidateUserByIdRequestClient _requestClient;
    private readonly IGetCurrentUserRequestClient _getCurrentUserRequestClient;

    public AddMessageCommandHandler(
        IMapper mapper,
        IMessageSender messageSender,
        IMessageRepository messageRepository,
        IValidateUserByIdRequestClient requestClient,
        IGetCurrentUserRequestClient getCurrentUserRequestClient)
    {
        _mapper = mapper;
        _messageSender = messageSender;
        _messageRepository = messageRepository;
        _requestClient = requestClient;
        _getCurrentUserRequestClient = getCurrentUserRequestClient;
    }

    public async Task Handle(AddMessageCommand request, CancellationToken cancellationToken)
    {
        var getCurrentUserRequest = _mapper.Map<GetCurrentUserRequest>(request);
        var getCurrentUserResponse = await _requestClient.GetResponse<GetCurrentUserResponse>(getCurrentUserRequest, cancellationToken);

        var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(request);
        var validateUserByIdResponse = await _requestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

        var message = _mapper.Map<Message>(request);
        _mapper.Map(getCurrentUserResponse.Message, message);
        await _messageRepository.AddAsync(message, cancellationToken);

        var sendMessageDTO = _mapper.Map<SendMessageDTO>(request);
        await _messageSender.SendMessageToUserAsync(sendMessageDTO);
    }
}
