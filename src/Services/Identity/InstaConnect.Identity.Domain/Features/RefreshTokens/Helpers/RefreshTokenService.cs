using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Identity.Domain.Helpers;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;
internal class RefreshTokenService : IRefreshTokenService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IRefreshTokenFactory _refreshTokenFactory;
    private readonly ISessionTokenFactory _sessionTokenFactory;
    private readonly IAccessTokenGenerator _accessTokenGenerator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserIncludeQueryBuilderFactory _userIncludeQueryBuilderFactory;

    public RefreshTokenService(
        IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        IDateTimeProvider dateTimeProvider,
        IRefreshTokenFactory refreshTokenFactory,
        ISessionTokenFactory sessionTokenFactory,
        IAccessTokenGenerator accessTokenGenerator,
        IRefreshTokenRepository refreshTokenRepository,
        IUserIncludeQueryBuilderFactory userIncludeQueryBuilderFactory)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
        _refreshTokenFactory = refreshTokenFactory;
        _sessionTokenFactory = sessionTokenFactory;
        _accessTokenGenerator = accessTokenGenerator;
        _refreshTokenRepository = refreshTokenRepository;
        _userIncludeQueryBuilderFactory = userIncludeQueryBuilderFactory;
    }

    public async Task<SessionToken> IssueAsync(IssueRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var include = _userIncludeQueryBuilderFactory.Create().WithClaims().Build();
        var existingUser = await _userRepository.GetByNameAsync(command.Name, include, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserInvalidDetailsException(command.Name);
        }

        var isMismatch = _passwordHasher.IsMismatch(command.Password, existingUser!.PasswordHash);

        if (isMismatch)
        {
            throw new UserInvalidDetailsException(command.Name);
        }

        var refreshToken = _refreshTokenFactory.Create(existingUser.Id);
        await _refreshTokenRepository.AddAsync(refreshToken, cancellationToken);

        var accessToken = _accessTokenGenerator.Generate(existingUser);
        var sessionToken = _sessionTokenFactory.Create(refreshToken, accessToken);

        return sessionToken;
    }

    public async Task<SessionToken> RotateAsync(RotateRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var include = _userIncludeQueryBuilderFactory.Create().WithClaims().Build();
        var existingUser = await _userRepository.GetByIdAsync(command.Id.Id, include, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id.Id);
        }

        var existingRefreshToken = await _refreshTokenRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingRefreshToken.IsNull())
        {
            throw new RefreshTokenNotFoundException(command.Id);
        }

        var utcNow = _dateTimeProvider.GetOffsetUtcNow();

        if (existingRefreshToken!.HasExpired(utcNow))
        {
            throw new RefreshTokenExpiredException(command.Id);
        }

        await _refreshTokenRepository.DeleteAsync(existingRefreshToken, cancellationToken);

        var refreshToken = _refreshTokenFactory.Create(existingUser!.Id);
        await _refreshTokenRepository.AddAsync(refreshToken, cancellationToken);

        var accessToken = _accessTokenGenerator.Generate(existingUser);
        var sessionToken = _sessionTokenFactory.Create(refreshToken, accessToken);

        return sessionToken;
    }

    public async Task DeleteAsync(DeleteRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(command.Id.Id, cancellationToken);

        if (existingUser.IsNull())
        {
            throw new UserNotFoundException(command.Id.Id);
        }

        var existingRefreshToken = await _refreshTokenRepository.GetByIdAsync(command.Id, cancellationToken);

        if (existingRefreshToken.IsNull())
        {
            throw new RefreshTokenNotFoundException(command.Id);
        }

        await _refreshTokenRepository.DeleteAsync(existingRefreshToken!, cancellationToken);
    }
}
