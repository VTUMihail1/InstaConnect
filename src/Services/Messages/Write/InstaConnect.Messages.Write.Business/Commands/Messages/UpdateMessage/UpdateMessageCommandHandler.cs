using AutoMapper;
using InstaConnect.Messages.Write.Data.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Messages;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Message;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Messages.Write.Business.Commands.Messages.UpdateMessage;

internal class UpdateMessageCommandHandler : ICommandHandler<UpdateMessageCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMessageRepository _messageRepository;

    public UpdateMessageCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint,
        IMessageRepository messageRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
        _messageRepository = messageRepository;
    }

    public async Task Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        var existingMessage = await _messageRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingMessage == null)
        {
            throw new MessageNotFoundException();
        }

        if (request.CurrentUserId != existingMessage.SenderId)
        {
            throw new AccountForbiddenException();
        }

        _mapper.Map(request, existingMessage);
        _messageRepository.Update(existingMessage);

        var messageUpdatedEvent = _mapper.Map<MessageCreatedEvent>(existingMessage);
        await _publishEndpoint.Publish(messageUpdatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
