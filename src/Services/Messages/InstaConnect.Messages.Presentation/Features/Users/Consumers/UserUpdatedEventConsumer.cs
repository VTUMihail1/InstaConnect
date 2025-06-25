namespace InstaConnect.Messages.Presentation.Features.Users.Consumers;

internal class UserUpdatedEventConsumer : IConsumer<UserUpdatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public UserUpdatedEventConsumer(
        IUnitOfWork unitOfWork,
        IApplicationMapper applicationMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _applicationMapper = applicationMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingUser == null)
        {
            return;
        }

        _applicationMapper.Map(context.Message, existingUser);
        _userWriteRepository.Update(existingUser);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
