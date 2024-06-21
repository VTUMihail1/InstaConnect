using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Users.Data.Abstraction;

namespace InstaConnect.Users.Business.Commands.Account.SendAccountPasswordReset;

public class SendAccountPasswordResetCommandHandler : ICommandHandler<SendAccountPasswordResetCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly ITokenRepository _tokenRepository;

    public SendAccountPasswordResetCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        ITokenGenerator tokenGenerator,
        ITokenRepository tokenRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
        _tokenRepository = tokenRepository;
    }

    public async Task Handle(SendAccountPasswordResetCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var token = _tokenGenerator.GeneratePasswordResetToken(existingUser.Id);
        _tokenRepository.Add(token);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
