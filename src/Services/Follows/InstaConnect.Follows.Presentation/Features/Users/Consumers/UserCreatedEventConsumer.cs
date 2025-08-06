namespace InstaConnect.Follows.Presentation.Features.Users.Consumers;

internal class UserCreatedEventConsumer : IConsumer<UserAddedEventRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public UserCreatedEventConsumer(
        IUnitOfWork unitOfWork,
        IApplicationMapper applicationMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _applicationMapper = applicationMapper;
        _userWriteRepository = userWriteRepository;
    }

    public async Task Consume(ConsumeContext<UserAddedEventRequest> context)
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
