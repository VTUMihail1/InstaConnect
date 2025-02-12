using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Exceptions.Token;
using InstaConnect.Shared.Common.Exceptions.User;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

public class VerifyForgotPasswordTokenCommandHandler : ICommandHandler<VerifyForgotPasswordTokenCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IForgotPasswordTokenWriteRepository _forgotPasswordTokenWriteRepository;

    public VerifyForgotPasswordTokenCommandHandler(
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
        VerifyForgotPasswordTokenCommand request,
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
