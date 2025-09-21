using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Models;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Repositories;

internal class UserClaimRepository : IUserClaimRepository
{
    private readonly IdentityContext _identityContext;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IUserClaimQueryFactory _userClaimQueryFactory;
    private readonly IUserClaimCollectionFactory _userClaimCollectionFactory;

    public UserClaimRepository(
        IdentityContext identityContext,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory,
        IUserClaimQueryFactory userClaimQueryFactory,
        IUserClaimCollectionFactory userClaimCollectionFactory)
    {
        _identityContext = identityContext;
        _applicationMapper = applicationMapper;
        _sqlConnectionFactory = sqlConnectionFactory;
        _userClaimQueryFactory = userClaimQueryFactory;
        _userClaimCollectionFactory = userClaimCollectionFactory;
    }

    public async Task<UserClaimCollection> GetAllAsync(GetAllUserClaimsQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllQuery = _userClaimQueryFactory.CreateGetAll(query);
        var queryEntity = await connection.ExecuteQueryAsync<UserClaimQueryEntity>(
            getAllQuery.Sql,
            getAllQuery.Parameters,
            cancellationToken);
        var userClaims = _applicationMapper.Map<ICollection<UserClaim>>(queryEntity.ToList());

        var response = _userClaimCollectionFactory.Create(userClaims);

        return response;
    }

    public void Add(UserClaim userClaim)
    {
        _identityContext
            .UserClaims
            .Add(userClaim);
    }
}
