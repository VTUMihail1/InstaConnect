using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Token;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Identity.Business.Commands.Account.ResetAccountPassword;

public class ResetAccountPasswordCommandHandler : ICommandHandler<ResetAccountPasswordCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly ITokenWriteRepository _tokenWriteRepository;

    public ResetAccountPasswordCommandHandler(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IUserWriteRepository userWriteRepository,
        ITokenWriteRepository tokenWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _userWriteRepository = userWriteRepository;
        _tokenWriteRepository = tokenWriteRepository;
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

        var existingToken = await _tokenWriteRepository.GetByValueAsync(request.Token, cancellationToken);

        if (existingToken == null)
        {
            throw new TokenNotFoundException();
        }

        if (existingToken.UserId != request.UserId)
        {
            throw new AccountForbiddenException();
        }

        var passwordHashResultDTO = _passwordHasher.Hash(request.Password);
        await _userWriteRepository.ResetPasswordAsync(existingUser.Id, passwordHashResultDTO.PasswordHash, cancellationToken);

        _tokenWriteRepository.Delete(existingToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
