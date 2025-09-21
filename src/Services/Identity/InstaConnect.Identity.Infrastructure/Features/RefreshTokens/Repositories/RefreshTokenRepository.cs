using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Abstractions;
using InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Models;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Repositories;

internal class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly IdentityContext _identityContext;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IRefreshTokenQueryFactory _refreshTokenQueryFactory;

    public RefreshTokenRepository(
        IdentityContext identityContext,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory,
        IRefreshTokenQueryFactory refreshTokenQueryFactory)
    {
        _identityContext = identityContext;
        _applicationMapper = applicationMapper;
        _sqlConnectionFactory = sqlConnectionFactory;
        _refreshTokenQueryFactory = refreshTokenQueryFactory;
    }

    public async Task<RefreshToken?> GetByIdAsync(string id, string value, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdQuery = _refreshTokenQueryFactory.CreateGetById(id, value);
        var queryResponse = await connection.ExecuteQueryFirstAsync<RefreshTokenQueryEntity>(
            getByIdQuery.Sql,
            getByIdQuery.Parameters,
            cancellationToken);
        var refreshToken = _applicationMapper.Map<RefreshToken>(queryResponse!);

        return refreshToken;
    }

    public void Add(RefreshToken refreshToken)
    {
        _identityContext
            .RefreshTokens
            .Add(refreshToken);
    }

    public void Delete(RefreshToken refreshToken)
    {
        _identityContext
            .RefreshTokens
            .Remove(refreshToken);
    }
}
