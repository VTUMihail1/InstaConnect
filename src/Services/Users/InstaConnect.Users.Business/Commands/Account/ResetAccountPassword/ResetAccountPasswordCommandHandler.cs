using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Token;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Users.Data.Abstraction;

namespace InstaConnect.Users.Business.Commands.Account.ResetAccountPassword;

public class ResetAccountPasswordCommandHandler : ICommandHandler<ResetAccountPasswordCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;

    public ResetAccountPasswordCommandHandler(
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        ITokenRepository tokenRepository)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
    }

    public async Task Handle(ResetAccountPasswordCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var existingToken = await _tokenRepository.GetByValueAsync(request.Token, cancellationToken);

        if (existingToken == null)
        {
            throw new TokenNotFoundException();
        }

        var passwordHashResultDTO = _passwordHasher.Hash(request.Password);
        await _userRepository.ResetPasswordAsync(existingUser.Id, passwordHashResultDTO.PasswordHash, cancellationToken);
        
        _tokenRepository.Delete(existingToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
