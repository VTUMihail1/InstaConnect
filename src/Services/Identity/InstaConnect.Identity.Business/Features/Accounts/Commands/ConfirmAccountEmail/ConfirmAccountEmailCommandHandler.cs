using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.Token;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ConfirmAccountEmail;

public class ConfirmAccountEmailCommandHandler : ICommandHandler<ConfirmAccountEmailCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IEmailConfirmationTokenWriteRepository _emailConfirmationTokenWriteRepository;

    public ConfirmAccountEmailCommandHandler(
        IUnitOfWork unitOfWork,
        IUserWriteRepository userWriteRepository,
        IEmailConfirmationTokenWriteRepository emailConfirmationTokenWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _userWriteRepository = userWriteRepository;
        _emailConfirmationTokenWriteRepository = emailConfirmationTokenWriteRepository;
    }

    public async Task Handle(
        ConfirmAccountEmailCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        if (existingUser.IsEmailConfirmed)
        {
            throw new AccountEmailAlreadyConfirmedException();
        }

        var existingToken = await _emailConfirmationTokenWriteRepository.GetByValueAsync(request.Token, cancellationToken);

        if (existingToken == null)
        {
            throw new TokenNotFoundException();
        }

        if (existingToken.UserId != request.UserId)
        {
            throw new AccountForbiddenException();
        }

        _emailConfirmationTokenWriteRepository.Delete(existingToken);

        await _userWriteRepository.ConfirmEmailAsync(existingUser.Id, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
