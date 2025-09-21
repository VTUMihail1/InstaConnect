using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Domain.Events.ForgotPasswordTokens;
using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Exceptions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.Users.Exceptions;
using InstaConnect.Identity.Domain.Helpers;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Users.Domain.Features.Users.Abstractions;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;
internal class ForgotPasswordTokenService : IForgotPasswordTokenService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IForgotPasswordTokenFactory _forgotPasswordTokenFactory;
    private readonly IForgotPasswordTokenRepository _forgotPasswordTokenRepository;

    public ForgotPasswordTokenService(
        IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        IEventPublisher eventPublisher,
        IDateTimeProvider dateTimeProvider,
        IApplicationMapper applicationMapper,
        IForgotPasswordTokenFactory forgotPasswordTokenFactory,
        IForgotPasswordTokenRepository forgotPasswordTokenRepository)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _eventPublisher = eventPublisher;
        _dateTimeProvider = dateTimeProvider;
        _applicationMapper = applicationMapper;
        _forgotPasswordTokenFactory = forgotPasswordTokenFactory;
        _forgotPasswordTokenRepository = forgotPasswordTokenRepository;
    }

    public async Task<ForgotPasswordToken> AddAsync(AddForgotPasswordTokenCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByNameAsync(command.Name, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Name);
        }

        var forgotPasswordToken = _forgotPasswordTokenFactory.Create(existingUser!.Id);
        _forgotPasswordTokenRepository.Add(forgotPasswordToken);

        var forgotPasswordTokenAddedEvent = _applicationMapper.Map<ForgotPasswordTokenAddedEventRequest>(forgotPasswordToken);
        await _eventPublisher.PublishAsync(forgotPasswordTokenAddedEvent, cancellationToken);

        return forgotPasswordToken;
    }

    public async Task VerifyAsync(VerifyForgotPasswordTokenCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id);
        }

        var existingForgotPasswordToken = await _forgotPasswordTokenRepository.GetByIdAsync(command.Id, command.Value, cancellationToken);

        if (existingForgotPasswordToken.IsNull())
        {
            throw new ForgotPasswordTokenNotFoundException(command.Id, command.Value);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();

        if (existingForgotPasswordToken!.HasExpired(utcNow))
        {
            throw new ForgotPasswordTokenExpiredException(command.Id, command.Value);
        }

        _forgotPasswordTokenRepository.Delete(existingForgotPasswordToken);

        var passwordHash = _passwordHasher.Hash(command.Password);

        existingUser!.UpdatePasswordHash(passwordHash);
        _userRepository.Update(existingUser);
    }
}
