namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;

public class AddForgotPasswordTokenCommandHandler : ICommandHandler<AddForgotPasswordTokenCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IForgotPasswordTokenPublisher _forgotPasswordTokenPublisher;

    public AddForgotPasswordTokenCommandHandler(
        IUnitOfWork unitOfWork,
        IApplicationMapper applicationMapper,
        IUserWriteRepository userWriteRepository,
        IForgotPasswordTokenPublisher forgotPasswordTokenPublisher)
    {
        _unitOfWork = unitOfWork;
        _applicationMapper = applicationMapper;
        _userWriteRepository = userWriteRepository;
        _forgotPasswordTokenPublisher = forgotPasswordTokenPublisher;
    }

    public async Task Handle(
        AddForgotPasswordTokenCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var createForgotPasswordTokenModel = _applicationMapper.Map<CreateForgotPasswordTokenModel>(existingUser);
        await _forgotPasswordTokenPublisher.PublishForgotPasswordTokenAsync(createForgotPasswordTokenModel, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
