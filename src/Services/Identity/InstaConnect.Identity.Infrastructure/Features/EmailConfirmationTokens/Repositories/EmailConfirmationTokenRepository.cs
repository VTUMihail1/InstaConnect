using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Models;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Response;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Repositories;

internal class EmailConfirmationTokenRepository : IEmailConfirmationTokenRepository
{
    private readonly IdentityContext _identityContext;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IEmailConfirmationTokenQueryFactory _emailConfirmationTokenQueryFactory;
    private readonly IEmailConfirmationTokenCollectionFactory _emailConfirmationTokenCollectionFactory;

    public EmailConfirmationTokenRepository(
        IdentityContext identityContext,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory,
        IEmailConfirmationTokenQueryFactory emailConfirmationTokenQueryFactory,
        IEmailConfirmationTokenCollectionFactory emailConfirmationTokenCollectionFactory)
    {
        _identityContext = identityContext;
        _applicationMapper = applicationMapper;
        _sqlConnectionFactory = sqlConnectionFactory;
        _emailConfirmationTokenQueryFactory = emailConfirmationTokenQueryFactory;
        _emailConfirmationTokenCollectionFactory = emailConfirmationTokenCollectionFactory;
    }

    public async Task<EmailConfirmationTokenCollection> GetAllAsync(GetAllEmailConfirmationTokensQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllQuery = _emailConfirmationTokenQueryFactory.CreateGetAll(query);
        var queryEntity = await connection.ExecuteQueryAsync<UserClaimQueryEntity>(
            getAllQuery.Sql,
            getAllQuery.Parameters,
            cancellationToken);
        var emailConfirmationTokens = _applicationMapper.Map<ICollection<EmailConfirmationToken>>(queryEntity.ToList());

        var response = _emailConfirmationTokenCollectionFactory.Create(emailConfirmationTokens);

        return response;
    }

    public async Task<EmailConfirmationToken?> GetByIdAsync(string id, string value, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdQuery = _emailConfirmationTokenQueryFactory.CreateGetById(id, value);
        var queryResponse = await connection.ExecuteQueryFirstAsync<EmailConfirmationTokenQueryEntity>(
            getByIdQuery.Sql,
            getByIdQuery.Parameters,
            cancellationToken);
        var emailConfirmationToken = _applicationMapper.Map<EmailConfirmationToken>(queryResponse!);

        return emailConfirmationToken;
    }

    public void Add(EmailConfirmationToken emailConfirmationToken)
    {
        _identityContext
            .EmailConfirmationTokens
            .Add(emailConfirmationToken);
    }

    public void Delete(EmailConfirmationToken emailConfirmationToken)
    {
        _identityContext
            .EmailConfirmationTokens
            .Remove(emailConfirmationToken);
    }

    public void DeleteRange(ICollection<EmailConfirmationToken> emailConfirmationTokens)
    {
        _identityContext
            .EmailConfirmationTokens
            .RemoveRange(emailConfirmationTokens);
    }
}
