using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Domain.Events.EmailConfirmationTokens;
using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Exceptions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.Users.Exceptions;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Users.Domain.Features.Users.Abstractions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;
internal class EmailConfirmationTokenService : IEmailConfirmationTokenService
{
    private readonly IUserRepository _userRepository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IEmailConfirmationTokenFactory _emailConfirmationTokenFactory;
    private readonly IEmailConfirmationTokenRepository _emailConfirmationTokenRepository;

    public EmailConfirmationTokenService(
        IUserRepository userRepository,
        IEventPublisher eventPublisher,
        IDateTimeProvider dateTimeProvider,
        IApplicationMapper applicationMapper,
        IEmailConfirmationTokenFactory emailConfirmationTokenFactory,
        IEmailConfirmationTokenRepository emailConfirmationTokenRepository)
    {
        _userRepository = userRepository;
        _eventPublisher = eventPublisher;
        _dateTimeProvider = dateTimeProvider;
        _applicationMapper = applicationMapper;
        _emailConfirmationTokenFactory = emailConfirmationTokenFactory;
        _emailConfirmationTokenRepository = emailConfirmationTokenRepository;
    }

    public async Task<EmailConfirmationToken> AddAsync(AddEmailConfirmationTokenCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByNameAsync(command.Name, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Name);
        }

        var emailConfirmationToken = _emailConfirmationTokenFactory.Create(existingUser!.Id);
        _emailConfirmationTokenRepository.Add(emailConfirmationToken);

        var emailConfirmationTokenAddedEvent = _applicationMapper.Map<EmailConfirmationTokenAddedEventRequest>(emailConfirmationToken);
        await _eventPublisher.PublishAsync(emailConfirmationTokenAddedEvent, cancellationToken);

        return emailConfirmationToken;
    }

    public async Task VerifyAsync(VerifyEmailConfirmationTokenCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id);
        }

        var existingEmailConfirmationToken = await _emailConfirmationTokenRepository.GetByIdAsync(command.Id, command.Value, cancellationToken);

        if (existingEmailConfirmationToken.IsNull())
        {
            throw new EmailConfirmationTokenNotFoundException(command.Id, command.Value);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();

        if (existingEmailConfirmationToken!.HasExpired(utcNow))
        {
            throw new EmailConfirmationTokenExpiredException(command.Id, command.Value);
        }

        _emailConfirmationTokenRepository.Delete(existingEmailConfirmationToken);

        existingUser!.ConfirmEmail();
        _userRepository.Update(existingUser);
    }
}
