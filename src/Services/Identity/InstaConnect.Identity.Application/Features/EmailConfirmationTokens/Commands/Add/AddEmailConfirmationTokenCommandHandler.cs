namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;

public class AddEmailConfirmationTokenCommandHandler : ICommandHandler<AddEmailConfirmationTokenCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IEmailConfirmationTokenPublisher _emailConfirmationTokenPublisher;

    public AddEmailConfirmationTokenCommandHandler(
        IUnitOfWork unitOfWork,
        IApplicationMapper applicationMapper,
        IUserWriteRepository userWriteRepository,
        IEmailConfirmationTokenPublisher emailConfirmationTokenPublisher)
    {
        _unitOfWork = unitOfWork;
        _applicationMapper = applicationMapper;
        _userWriteRepository = userWriteRepository;
        _emailConfirmationTokenPublisher = emailConfirmationTokenPublisher;
    }

    public async Task Handle(
        AddEmailConfirmationTokenCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        if (existingUser.IsEmailConfirmed)
        {
            throw new UserEmailAlreadyConfirmedException();
        }

        var createEmailConfirmationTokenModel = _applicationMapper.Map<CreateEmailConfirmationTokenModel>(existingUser);
        await _emailConfirmationTokenPublisher.PublishEmailConfirmationTokenAsync(createEmailConfirmationTokenModel, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
