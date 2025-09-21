using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Follows.Infrastructure;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly FollowsContext _followsContext;
    private readonly IUserQueryFactory _userQueryFactory;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public UserRepository(
        FollowsContext followsContext,
        IUserQueryFactory userQueryFactory,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory)
    {
        _followsContext = followsContext;
        _userQueryFactory = userQueryFactory;
        _applicationMapper = applicationMapper;
        _sqlConnectionFactory = sqlConnectionFactory;
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
        _followsContext
            .Users
            .Add(user);
    }

    public void Update(User user)
    {
        _followsContext
            .Users
            .Update(user);
    }

    public void Delete(User user)
    {
        _followsContext
            .Users
            .Remove(user);
    }
}
