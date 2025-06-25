namespace InstaConnect.Messages.Application.Features.Messages.Commands.Update;

internal class UpdateMessageCommandHandler : ICommandHandler<UpdateMessageCommand, MessageCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMessageService _messageService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IMessageWriteRepository _messageWriteRepository;

    public UpdateMessageCommandHandler(
        IUnitOfWork unitOfWork,
        IMessageService messageService,
        IApplicationMapper applicationMapper,
        IMessageWriteRepository messageWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _messageService = messageService;
        _applicationMapper = applicationMapper;
        _messageWriteRepository = messageWriteRepository;
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

        _messageService.Update(existingMessage, request.Content);
        _messageWriteRepository.Update(existingMessage);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var messageViewModel = _applicationMapper.Map<MessageCommandViewModel>(existingMessage);

        return messageViewModel;
    }
}
