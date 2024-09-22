using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Token;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ResetAccountPassword;

public class ResetAccountPasswordCommandHandler : ICommandHandler<ResetAccountPasswordCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IEmailConfirmationTokenWriteRepository _emailConfirmationTokenWriteRepository;

    public ResetAccountPasswordCommandHandler(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IUserWriteRepository userWriteRepository,
        IEmailConfirmationTokenWriteRepository emailConfirmationTokenWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _userWriteRepository = userWriteRepository;
        _emailConfirmationTokenWriteRepository = emailConfirmationTokenWriteRepository;
    }

    public async Task Handle(
        ResetAccountPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var existingEmailConfirmationToken = await _emailConfirmationTokenWriteRepository.GetByValueAsync(request.Token, cancellationToken);

        if (existingEmailConfirmationToken == null)
        {
            throw new TokenNotFoundException();
        }

        if (existingEmailConfirmationToken.UserId != request.UserId)
        {
            throw new AccountForbiddenException();
        }

        var passwordHashResultModel = _passwordHasher.Hash(request.Password);
        await _userWriteRepository.ResetPasswordAsync(existingUser.Id, passwordHashResultModel.PasswordHash, cancellationToken);

        _emailConfirmationTokenWriteRepository.Delete(existingEmailConfirmationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
