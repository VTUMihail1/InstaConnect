using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Token;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Users.Business.Abstractions;
using InstaConnect.Users.Data.Abstraction.Helpers;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.Account.ConfirmAccountEmail;

public class ConfirmAccountEmailCommandHandler : ICommandHandler<ConfirmAccountEmailCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly ITokenRepository _tokenRepository;

    public ConfirmAccountEmailCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        ITokenRepository tokenRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _tokenRepository = tokenRepository;
    }

    public async Task Handle(ConfirmAccountEmailCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        if (existingUser.IsEmailConfirmed)
        {
            throw new AccountEmailAlreadyConfirmedException();
        }

        var existingToken = await _tokenRepository.GetByValueAsync(request.Token, cancellationToken);

        if(existingToken == null)
        {
            throw new TokenNotFoundException();
        }

        _tokenRepository.Delete(existingToken);

        await _userRepository.ConfirmEmailAsync(existingUser.Id, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
