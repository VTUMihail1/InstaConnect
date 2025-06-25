namespace InstaConnect.Posts.Presentation.Features.Users.Consumers;

internal class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserRepository _userWriteRepository;

    public UserCreatedEventConsumer(
        IUnitOfWork unitOfWork,
        IApplicationMapper applicationMapper,
        IUserRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _applicationMapper = applicationMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingUser != null)
        {
            return;
        }

        var user = _applicationMapper.Map<User>(context.Message);
        _userWriteRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}
