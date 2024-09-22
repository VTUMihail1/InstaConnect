using InstaConnect.Identity.Business.Features.Accounts.Abstractions;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.SendAccountPasswordReset;

public class SendAccountPasswordResetCommandHandler : ICommandHandler<SendAccountPasswordResetCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IForgotPasswordTokenPublisher _forgotPasswordTokenPublisher;

    public SendAccountPasswordResetCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IForgotPasswordTokenPublisher forgotPasswordTokenPublisher)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _forgotPasswordTokenPublisher = forgotPasswordTokenPublisher;
    }

    public async Task Handle(
        SendAccountPasswordResetCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var createForgotPasswordTokenModel = _instaConnectMapper.Map<CreateForgotPasswordTokenModel>(existingUser);
        await _forgotPasswordTokenPublisher.PublishForgotPasswordTokenAsync(createForgotPasswordTokenModel, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
