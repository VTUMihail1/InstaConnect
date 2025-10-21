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
    private readonly IUserIncludeQueryBuilderFactory _userIncludeQueryBuilderFactory;

    public ForgotPasswordTokenService(
        IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        IEventPublisher eventPublisher,
        IDateTimeProvider dateTimeProvider,
        IApplicationMapper applicationMapper,
        IForgotPasswordTokenFactory forgotPasswordTokenFactory,
        IForgotPasswordTokenRepository forgotPasswordTokenRepository,
        IUserIncludeQueryBuilderFactory userIncludeQueryBuilderFactory)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _eventPublisher = eventPublisher;
        _dateTimeProvider = dateTimeProvider;
        _applicationMapper = applicationMapper;
        _forgotPasswordTokenFactory = forgotPasswordTokenFactory;
        _forgotPasswordTokenRepository = forgotPasswordTokenRepository;
        _userIncludeQueryBuilderFactory = userIncludeQueryBuilderFactory;
    }

    public async Task<ForgotPasswordToken> AddAsync(AddForgotPasswordTokenCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByNameAsync(command.Name, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Name);
        }

        var forgotPasswordToken = _forgotPasswordTokenFactory.Create(existingUser!.Id);
        await _forgotPasswordTokenRepository.AddAsync(forgotPasswordToken, cancellationToken);

        var forgotPasswordTokenAddedEvent = _applicationMapper.Map<ForgotPasswordTokenAddedEventRequest>(forgotPasswordToken);
        await _eventPublisher.PublishAsync(forgotPasswordTokenAddedEvent, cancellationToken);

        return forgotPasswordToken;
    }

    public async Task VerifyAsync(VerifyForgotPasswordTokenCommand command, CancellationToken cancellationToken)
    {
        var include = _userIncludeQueryBuilderFactory.Create().WithForgotPasswordTokens().Build();
        var existingUser = await _userRepository.GetByIdAsync(command.Id, include, cancellationToken);

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

        await _forgotPasswordTokenRepository.DeleteRangeAsync(existingUser!.ForgotPasswordTokens, cancellationToken);

        var passwordHash = _passwordHasher.Hash(command.Password);

        existingUser!.UpdatePasswordHash(passwordHash);
        await _userRepository.UpdateAsync(existingUser, cancellationToken);
    }
}
