using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Commands.SendUserPasswordReset;

public class SendUserPasswordResetCommandHandler : ICommandHandler<SendUserPasswordResetCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IForgotPasswordTokenPublisher _forgotPasswordTokenPublisher;

    public SendUserPasswordResetCommandHandler(
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
        SendUserPasswordResetCommand request,
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
