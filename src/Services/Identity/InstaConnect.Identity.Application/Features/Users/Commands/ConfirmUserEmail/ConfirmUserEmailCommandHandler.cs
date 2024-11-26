using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Exceptions.Token;
using InstaConnect.Shared.Common.Exceptions.User;

namespace InstaConnect.Identity.Application.Features.Users.Commands.ConfirmUserEmail;

public class ConfirmUserEmailCommandHandler : ICommandHandler<ConfirmUserEmailCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IEmailConfirmationTokenWriteRepository _emailConfirmationTokenWriteRepository;

    public ConfirmUserEmailCommandHandler(
        IUnitOfWork unitOfWork,
        IUserWriteRepository userWriteRepository,
        IEmailConfirmationTokenWriteRepository emailConfirmationTokenWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _userWriteRepository = userWriteRepository;
        _emailConfirmationTokenWriteRepository = emailConfirmationTokenWriteRepository;
    }

    public async Task Handle(
        ConfirmUserEmailCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        if (existingUser.IsEmailConfirmed)
        {
            throw new UserEmailAlreadyConfirmedException();
        }

        var existingToken = await _emailConfirmationTokenWriteRepository.GetByValueAsync(request.Token, cancellationToken);

        if (existingToken == null)
        {
            throw new TokenNotFoundException();
        }

        if (existingToken.UserId != request.UserId)
        {
            throw new UserForbiddenException();
        }

        _emailConfirmationTokenWriteRepository.Delete(existingToken);

        await _userWriteRepository.ConfirmEmailAsync(existingUser.Id, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
