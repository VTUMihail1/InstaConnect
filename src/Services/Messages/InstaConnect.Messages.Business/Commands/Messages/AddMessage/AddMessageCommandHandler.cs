using InstaConnect.Messages.Business.Abstract;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Messages.Business.Commands.Messages.AddMessage;

internal class AddMessageCommandHandler : ICommandHandler<AddMessageCommand, MessageCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageSender _messageSender;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IMessageWriteRepository _messageWriteRepository;

    public AddMessageCommandHandler(
        IUnitOfWork unitOfWork,
        IMessageSender messageSender,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IMessageWriteRepository messageWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _messageSender = messageSender;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _messageWriteRepository = messageWriteRepository;
    }

    public async Task<MessageCommandViewModel> Handle(
        AddMessageCommand request, 
        CancellationToken cancellationToken)
    {
        var existingSender = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingSender == null)
        {
            throw new UserNotFoundException();
        }

        var existingReceiver = await _userWriteRepository.GetByIdAsync(request.ReceiverId, cancellationToken);

        if (existingReceiver == null)
        {
            throw new UserNotFoundException();
        }

        var message = _instaConnectMapper.Map<Message>(request);
        _messageWriteRepository.Add(message);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var messageSendModel = _instaConnectMapper.Map<MessageSendModel>(message);
        await _messageSender.SendMessageToUserAsync(messageSendModel, cancellationToken);

        var messageViewModel = _instaConnectMapper.Map<MessageCommandViewModel>(message);

        return messageViewModel;
    }
}
