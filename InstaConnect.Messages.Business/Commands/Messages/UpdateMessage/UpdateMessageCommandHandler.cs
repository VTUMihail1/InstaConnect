using AutoMapper;
using InstaConnect.Messages.Data.Abstractions.Repositories;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;

internal class UpdateMessageCommandHandler : ICommandHandler<UpdateMessageCommand>
{
    private readonly IMapper _mapper;
    private readonly IMessageRepository _messageRepository;
    private readonly IRequestClient<ValidateUserByIdRequest> _validateUserByIdRequestClient;

    public UpdateMessageCommandHandler(
        IMapper mapper,
        IMessageRepository messageRepository,
        IRequestClient<ValidateUserByIdRequest> validateUserByIdRequestClient)
    {
        _mapper = mapper;
        _messageRepository = messageRepository;
        _validateUserByIdRequestClient = validateUserByIdRequestClient;
    }

    public async Task Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        var existingMessage = await _messageRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingMessage == null)
        {
            throw new MessageNotFoundException();
        }

        var validateUserByIdRequest = _mapper.Map<ValidateUserByIdRequest>(request);
        await _validateUserByIdRequestClient.GetResponse<ValidateUserByIdResponse>(validateUserByIdRequest, cancellationToken);

        _mapper.Map(request, existingMessage);
        await _messageRepository.UpdateAsync(existingMessage, cancellationToken);
    }
}
