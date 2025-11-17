using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Events.Abstractions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;
internal class EmailConfirmationTokenService : IEmailConfirmationTokenService
{
    private readonly IUserRepository _userRepository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IEmailConfirmationTokenFactory _emailConfirmationTokenFactory;
    private readonly IUserIncludeQueryBuilderFactory _userIncludeQueryBuilderFactory;
    private readonly IEmailConfirmationTokenRepository _emailConfirmationTokenRepository;

    public EmailConfirmationTokenService(
        IUserRepository userRepository,
        IEventPublisher eventPublisher,
        IDateTimeProvider dateTimeProvider,
        IApplicationMapper applicationMapper,
        IEmailConfirmationTokenFactory emailConfirmationTokenFactory,
        IUserIncludeQueryBuilderFactory userIncludeQueryBuilderFactory,
        IEmailConfirmationTokenRepository emailConfirmationTokenRepository)
    {
        _userRepository = userRepository;
        _eventPublisher = eventPublisher;
        _dateTimeProvider = dateTimeProvider;
        _applicationMapper = applicationMapper;
        _emailConfirmationTokenFactory = emailConfirmationTokenFactory;
        _userIncludeQueryBuilderFactory = userIncludeQueryBuilderFactory;
        _emailConfirmationTokenRepository = emailConfirmationTokenRepository;
    }

    public async Task<EmailConfirmationToken> AddAsync(AddEmailConfirmationTokenCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByNameAsync(command.Name, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNameNotFoundException(command.Name);
        }

        var emailConfirmationToken = _emailConfirmationTokenFactory.Create(existingUser!.Id);
        await _emailConfirmationTokenRepository.AddAsync(emailConfirmationToken, cancellationToken);

        var emailConfirmationTokenAddedEvent = _applicationMapper.Map<EmailConfirmationTokenAddedEventRequest>(emailConfirmationToken);
        await _eventPublisher.PublishAsync(emailConfirmationTokenAddedEvent, cancellationToken);

        return emailConfirmationToken;
    }

    public async Task VerifyAsync(VerifyEmailConfirmationTokenCommand command, CancellationToken cancellationToken)
    {
        var include = _userIncludeQueryBuilderFactory.Create().WithEmailConfirmationTokens().Build();
        var existingUser = await _userRepository.GetByIdAsync(command.Id.Id, include, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id.Id);
        }

        var existingEmailConfirmationToken = await _emailConfirmationTokenRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingEmailConfirmationToken.IsNull())
        {
            throw new EmailConfirmationTokenNotFoundException(command.Id);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();

        if (existingEmailConfirmationToken!.HasExpired(utcNow))
        {
            throw new EmailConfirmationTokenExpiredException(command.Id);
        }

        await _emailConfirmationTokenRepository.DeleteRangeAsync(existingUser!.EmailConfirmationTokens, cancellationToken);

        existingUser!.ConfirmEmail();
        await _userRepository.UpdateAsync(existingUser, cancellationToken);
    }
}
