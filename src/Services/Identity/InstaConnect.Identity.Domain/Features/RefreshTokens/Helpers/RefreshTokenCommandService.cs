using InstaConnect.Identity.Domain.Helpers;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;
internal class RefreshTokenCommandService : IRefreshTokenCommandService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserCommandRepository _repository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IRefreshTokenFactory _refreshTokenFactory;
    private readonly ISessionTokenGenerator _sessionTokenGenerator;
    private readonly IRefreshTokenCommandRepository _refreshTokenRepository;
    private readonly IUserIncludeBuilderFactory _includeQueryBuilderFactory;

    public RefreshTokenCommandService(
        IPasswordHasher passwordHasher,
        IUserCommandRepository repository,
        IDateTimeProvider dateTimeProvider,
        IRefreshTokenFactory refreshTokenFactory,
        ISessionTokenGenerator sessionTokenGenerator,
        IRefreshTokenCommandRepository refreshTokenRepository,
        IUserIncludeBuilderFactory includeQueryBuilderFactory)
    {
        _passwordHasher = passwordHasher;
        _repository = repository;
        _dateTimeProvider = dateTimeProvider;
        _refreshTokenFactory = refreshTokenFactory;
        _sessionTokenGenerator = sessionTokenGenerator;
        _refreshTokenRepository = refreshTokenRepository;
        _includeQueryBuilderFactory = includeQueryBuilderFactory;
    }

    public async Task<SessionToken> IssueAsync(IssueRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var include = _includeQueryBuilderFactory.Create().WithClaims().Build();
        var user = await _repository.GetByNameAsync(command.Name, include, cancellationToken);

        if (user == null)
        {
            throw new UserInvalidDetailsException(command.Name);
        }

        var isMismatch = _passwordHasher.IsMismatch(command.Password, user.PasswordHash);

        if (isMismatch)
        {
            throw new UserInvalidDetailsException(command.Name);
        }

        var newRefreshToken = _refreshTokenFactory.Create(user.Id);
        await _refreshTokenRepository.AddAsync(newRefreshToken, cancellationToken);

        newRefreshToken.AddUser(user);

        return _sessionTokenGenerator.Generate(newRefreshToken.AddUser(user));
    }

    public async Task<SessionToken> RotateAsync(RotateRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var include = _includeQueryBuilderFactory.Create().WithClaims().Build();
        var user = await _repository.GetByIdAsync(command.Id.Id, include, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(command.Id.Id);
        }

        var refreshToken = await _refreshTokenRepository.GetByIdAsync(command.Id, cancellationToken);

        if (refreshToken == null)
        {
            throw new RefreshTokenNotFoundException(command.Id);
        }

        if (refreshToken.HasExpired(_dateTimeProvider.GetOffsetUtcNow()))
        {
            throw new RefreshTokenExpiredException(command.Id);
        }

        await _refreshTokenRepository.DeleteAsync(refreshToken, cancellationToken);

        var newRefreshToken = _refreshTokenFactory.Create(user.Id).AddUser(user);
        await _refreshTokenRepository.AddAsync(newRefreshToken, cancellationToken);

        return _sessionTokenGenerator.Generate(newRefreshToken.AddUser(user));
    }

    public async Task DeleteAsync(DeleteRefreshTokenCommand command, CancellationToken cancellationToken)
    {
        var include = _includeQueryBuilderFactory.Create().WithClaims().Build();
        var user = await _repository.GetByIdAsync(command.Id.Id, include, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(command.Id.Id);
        }

        var refreshToken = await _refreshTokenRepository.GetByIdAsync(command.Id, cancellationToken);

        if (refreshToken == null)
        {
            throw new RefreshTokenNotFoundException(command.Id);
        }

        refreshToken.AddUser(user);

        await _refreshTokenRepository.DeleteAsync(refreshToken, cancellationToken);
    }
}
