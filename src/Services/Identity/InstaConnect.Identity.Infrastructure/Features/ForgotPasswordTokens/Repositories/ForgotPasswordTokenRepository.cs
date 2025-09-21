using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Models;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Repositories;

internal class ForgotPasswordTokenRepository : IForgotPasswordTokenRepository
{
    private readonly IdentityContext _identityContext;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IForgotPasswordTokenQueryFactory _forgotPasswordTokenQueryFactory;

    public ForgotPasswordTokenRepository(
        IdentityContext identityContext,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory,
        IForgotPasswordTokenQueryFactory forgotPasswordTokenQueryFactory)
    {
        _identityContext = identityContext;
        _applicationMapper = applicationMapper;
        _sqlConnectionFactory = sqlConnectionFactory;
        _forgotPasswordTokenQueryFactory = forgotPasswordTokenQueryFactory;
    }

    public async Task<ForgotPasswordToken?> GetByIdAsync(string id, string value, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdQuery = _forgotPasswordTokenQueryFactory.CreateGetById(id, value);
        var queryResponse = await connection.ExecuteQueryFirstAsync<ForgotPasswordTokenQueryEntity>(
            getByIdQuery.Sql,
            getByIdQuery.Parameters,
            cancellationToken);
        var forgotPasswordToken = _applicationMapper.Map<ForgotPasswordToken>(queryResponse!);

        return forgotPasswordToken;
    }

    public void Add(ForgotPasswordToken forgotPasswordToken)
    {
        _identityContext
            .ForgotPasswordTokens
            .Add(forgotPasswordToken);
    }

    public void Delete(ForgotPasswordToken forgotPasswordToken)
    {
        _identityContext
            .ForgotPasswordTokens
            .Remove(forgotPasswordToken);
    }
}
