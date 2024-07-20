using InstaConnect.Messages.Business.Abstract;
using InstaConnect.Messages.Business.Models;
using InstaConnect.Messages.Data.Abstractions;
using InstaConnect.Messages.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Messages.Business.Commands.Messages.AddMessage;

internal class AddMessageCommandHandler : ICommandHandler<AddMessageCommand, MessageWriteViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageSender _messageSender;
    private readonly IMessageWriteRepository _messageRepository;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public AddMessageCommandHandler(
        IUnitOfWork unitOfWork,
        IMessageSender messageSender,
        IMessageWriteRepository messageRepository,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _messageSender = messageSender;
        _messageRepository = messageRepository;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<MessageWriteViewModel> Handle(AddMessageCommand request, CancellationToken cancellationToken)
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
        _messageRepository.Add(message);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var messageSendModel = _instaConnectMapper.Map<MessageSendModel>(message);
        await _messageSender.SendMessageToUserAsync(messageSendModel, cancellationToken);

        var messageViewModel = _instaConnectMapper.Map<MessageWriteViewModel>(message);

        return messageViewModel;
    }
}
