using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Identity.Infrastructure;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Abstractions;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;
using InstaConnect.Users.Infrastructure.Features.Users.Models;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly IdentityContext _identityContext;
    private readonly IUserQueryFactory _userQueryFactory;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;
    private readonly IUserCollectionFactory _userCollectionFactory;

    public UserRepository(
        IdentityContext identityContext,
        IUserQueryFactory userQueryFactory,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory,
        IUserCollectionFactory userCollectionFactory)
    {
        _identityContext = identityContext;
        _userQueryFactory = userQueryFactory;
        _applicationMapper = applicationMapper;
        _sqlConnectionFactory = sqlConnectionFactory;
        _userCollectionFactory = userCollectionFactory;
    }

    public async Task<UserCollection> GetAllAsync(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getAllQuery = _userQueryFactory.CreateGetAll(query);
        var queryEntity = await connection.ExecuteQueryAsync<UserQueryEntity>(
            getAllQuery.Sql,
            getAllQuery.Parameters,
            cancellationToken);
        var users = _applicationMapper.Map<ICollection<User>>(queryEntity.ToList());

        var getAllTotalCountQuery = _userQueryFactory.CreateGetAllTotalCount(query.Filter);
        var usersTotalCount = await connection.ExecuteFunctionAsync<int>(getAllTotalCountQuery.Sql, getAllTotalCountQuery.Parameters, cancellationToken);

        var response = _userCollectionFactory.Create(users, usersTotalCount, query.Pagination);

        return response;
    }

    public async Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByIdQuery = _userQueryFactory.CreateGetById(id);
        var queryResponse = await connection.ExecuteQueryFirstAsync<UserQueryEntity>(
            getByIdQuery.Sql,
            getByIdQuery.Parameters,
            cancellationToken);
        var user = _applicationMapper.Map<User>(queryResponse!);

        return user;
    }

    public async Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByNameQuery = _userQueryFactory.CreateGetByName(name);
        var queryResponse = await connection.ExecuteQueryFirstAsync<UserQueryEntity>(
            getByNameQuery.Sql,
            getByNameQuery.Parameters,
            cancellationToken);
        var user = _applicationMapper.Map<User>(queryResponse!);

        return user;
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.Create();

        var getByEmailQuery = _userQueryFactory.CreateGetByEmail(email);
        var queryResponse = await connection.ExecuteQueryFirstAsync<UserQueryEntity>(
            getByEmailQuery.Sql,
            getByEmailQuery.Parameters,
            cancellationToken);
        var user = _applicationMapper.Map<User>(queryResponse!);

        return user;
    }

    public void Add(User user)
    {
        _identityContext
            .Users
            .Add(user);
    }

    public void Update(User user)
    {
        _identityContext
            .Users
            .Update(user);
    }

    public void Delete(User user)
    {
        _identityContext
            .Users
            .Remove(user);
    }
}
