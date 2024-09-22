using InstaConnect.Identity.Business.Features.Accounts.Abstractions;
using InstaConnect.Identity.Business.Features.Accounts.Models;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ResendAccountEmailConfirmation;

public class ResendAccountEmailConfirmationCommandHandler : ICommandHandler<ResendAccountEmailConfirmationCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IEmailConfirmationTokenPublisher _emailConfirmationTokenPublisher;

    public ResendAccountEmailConfirmationCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IEmailConfirmationTokenPublisher emailConfirmationTokenPublisher)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _emailConfirmationTokenPublisher = emailConfirmationTokenPublisher;
    }

    public async Task Handle(
        ResendAccountEmailConfirmationCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userWriteRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        if (existingUser.IsEmailConfirmed)
        {
            throw new AccountEmailAlreadyConfirmedException();
        }

        var createEmailConfirmationTokenModel = _instaConnectMapper.Map<CreateEmailConfirmationTokenModel>(existingUser);
        await _emailConfirmationTokenPublisher.PublishEmailConfirmationTokenAsync(createEmailConfirmationTokenModel, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
