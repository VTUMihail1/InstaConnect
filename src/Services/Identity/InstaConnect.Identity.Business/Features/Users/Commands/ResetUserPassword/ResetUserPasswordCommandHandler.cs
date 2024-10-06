using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Common.Exceptions.Token;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Commands.ResetUserPassword;

public class ResetUserPasswordCommandHandler : ICommandHandler<ResetUserPasswordCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IForgotPasswordTokenWriteRepository _forgotPasswordTokenWriteRepository;

    public ResetUserPasswordCommandHandler(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IUserWriteRepository userWriteRepository,
        IForgotPasswordTokenWriteRepository forgotPasswordTokenWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _userWriteRepository = userWriteRepository;
        _forgotPasswordTokenWriteRepository = forgotPasswordTokenWriteRepository;
    }

    public async Task Handle(
        ResetUserPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var existingForgotPasswordToken = await _forgotPasswordTokenWriteRepository.GetByValueAsync(request.Token, cancellationToken);

        if (existingForgotPasswordToken == null)
        {
            throw new TokenNotFoundException();
        }

        if (existingForgotPasswordToken.UserId != request.UserId)
        {
            throw new UserForbiddenException();
        }

        var passwordHashResultModel = _passwordHasher.Hash(request.Password);
        await _userWriteRepository.ResetPasswordAsync(existingUser.Id, passwordHashResultModel.PasswordHash, cancellationToken);

        _forgotPasswordTokenWriteRepository.Delete(existingForgotPasswordToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
