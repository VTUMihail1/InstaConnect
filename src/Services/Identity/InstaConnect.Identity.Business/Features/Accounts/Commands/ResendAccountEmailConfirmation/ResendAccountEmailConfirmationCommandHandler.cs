using InstaConnect.Identity.Data.Features.Tokens.Abstractions;
using InstaConnect.Identity.Data.Features.Tokens.Models;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Emails;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Identity.Business.Features.Accounts.Commands.ResendAccountEmailConfirmation;

public class ResendAccountEmailConfirmationCommandHandler : ICommandHandler<ResendAccountEmailConfirmationCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;

    public ResendAccountEmailConfirmationCommandHandler(
        IUnitOfWork unitOfWork,
        IEventPublisher eventPublisher,
        ITokenGenerator tokenGenerator,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
        _tokenGenerator = tokenGenerator;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
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

        var createAccountTokenModel = _instaConnectMapper.Map<CreateAccountTokenModel>(existingUser);
        var token = _tokenGenerator.GenerateEmailConfirmationToken(createAccountTokenModel);

        var userConfirmEmailTokenCreatedEvent = _instaConnectMapper.Map<UserConfirmEmailTokenCreatedEvent>((token, existingUser));
        await _eventPublisher.PublishAsync(userConfirmEmailTokenCreatedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
