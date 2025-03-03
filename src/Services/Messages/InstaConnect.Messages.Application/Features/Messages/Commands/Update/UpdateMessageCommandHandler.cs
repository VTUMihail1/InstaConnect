﻿namespace InstaConnect.Messages.Application.Features.Messages.Commands.Update;

internal class UpdateMessageCommandHandler : ICommandHandler<UpdateMessageCommand, MessageCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IMessageWriteRepository _messageWriteRepository;

    public UpdateMessageCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IMessageWriteRepository messageWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _messageWriteRepository = messageWriteRepository;
        _instaConnectMapper = instaConnectMapper;
    }

    public async Task<MessageCommandViewModel> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        var existingMessage = await _messageWriteRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingMessage == null)
        {
            throw new MessageNotFoundException();
        }

        if (request.CurrentUserId != existingMessage.SenderId)
        {
            throw new UserForbiddenException();
        }

        _instaConnectMapper.Map(request, existingMessage);
        _messageWriteRepository.Update(existingMessage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var messageViewModel = _instaConnectMapper.Map<MessageCommandViewModel>(existingMessage);

        return messageViewModel;
    }
}
