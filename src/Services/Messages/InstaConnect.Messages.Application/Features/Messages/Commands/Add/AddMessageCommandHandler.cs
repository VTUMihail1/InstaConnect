using InstaConnect.Messages.Domain.Features.Messages.Models;

namespace InstaConnect.Messages.Application.Features.Messages.Commands.Add;

internal class AddMessageCommandHandler : ICommandHandler<AddMessageCommand, MessageCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageSender _messageSender;
    private readonly IMessageFactory _messageFactory;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IMessageWriteRepository _messageWriteRepository;

    public AddMessageCommandHandler(
        IUnitOfWork unitOfWork,
        IMessageSender messageSender,
        IMessageFactory messageFactory,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IMessageWriteRepository messageWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _messageSender = messageSender;
        _messageFactory = messageFactory;
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

        var message = _messageFactory.Get(request.CurrentUserId, request.ReceiverId, request.Content);
        _messageWriteRepository.Add(message);

        var messageSendModel = _instaConnectMapper.Map<MessageSendModel>(message);
        await _messageSender.SendMessageToUserAsync(messageSendModel, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var messageViewModel = _instaConnectMapper.Map<MessageCommandViewModel>(message);

        return messageViewModel;
    }
}
