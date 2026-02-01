using InstaConnect.Common.Events.Abstractions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;
internal class EmailConfirmationTokenCommandService : IEmailConfirmationTokenCommandService
{
    private readonly IApplicationMapper _mapper;
    private readonly IEventPublisher _eventPublisher;
    private readonly IUserCommandRepository _repository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserIncludeBuilderFactory _includeQueryBuilderFactory;
    private readonly IEmailConfirmationTokenFactory _emailConfirmationTokenFactory;
    private readonly IEmailConfirmationTokenCommandRepository _emailConfirmationTokenRepository;

    public EmailConfirmationTokenCommandService(
        IApplicationMapper mapper,
        IEventPublisher eventPublisher,
        IUserCommandRepository repository,
        IDateTimeProvider dateTimeProvider,
        IUserIncludeBuilderFactory includeQueryBuilderFactory,
        IEmailConfirmationTokenFactory emailConfirmationTokenFactory,
        IEmailConfirmationTokenCommandRepository emailConfirmationTokenRepository)
    {
        _mapper = mapper;
        _eventPublisher = eventPublisher;
        _repository = repository;
        _dateTimeProvider = dateTimeProvider;
        _includeQueryBuilderFactory = includeQueryBuilderFactory;
        _emailConfirmationTokenFactory = emailConfirmationTokenFactory;
        _emailConfirmationTokenRepository = emailConfirmationTokenRepository;
    }

    public async Task<EmailConfirmationToken> AddAsync(AddEmailConfirmationTokenCommand command, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByNameAsync(command.Name, cancellationToken);

        if (user == null)
        {
            throw new UserNameNotFoundException(command.Name);
        }

        var newEmailConfirmationToken = _emailConfirmationTokenFactory.Create(user.Id);
        await _emailConfirmationTokenRepository.AddAsync(newEmailConfirmationToken, cancellationToken);

        await _eventPublisher.PublishAsync(
            _mapper.Map<EmailConfirmationTokenAddedEventRequest>(newEmailConfirmationToken.AddUser(user)), cancellationToken);

        return newEmailConfirmationToken;
    }

    public async Task VerifyAsync(VerifyEmailConfirmationTokenCommand command, CancellationToken cancellationToken)
    {
        var include = _includeQueryBuilderFactory.Create().WithEmailConfirmationTokens().Build();
        var user = await _repository.GetByIdAsync(command.Id.Id, include, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(command.Id.Id);
        }

        var emailConfirmationToken = await _emailConfirmationTokenRepository.GetByIdAsync(command.Id, cancellationToken);

        if (emailConfirmationToken == null)
        {
            throw new EmailConfirmationTokenNotFoundException(command.Id);
        }

        if (emailConfirmationToken.HasExpired(_dateTimeProvider.GetOffsetUtcNow()))
        {
            throw new EmailConfirmationTokenExpiredException(command.Id);
        }

        await _emailConfirmationTokenRepository.DeleteRangeAsync(user.EmailConfirmationTokens, cancellationToken);

        user.ConfirmEmail();
        await _repository.UpdateAsync(user, cancellationToken);
    }
}
