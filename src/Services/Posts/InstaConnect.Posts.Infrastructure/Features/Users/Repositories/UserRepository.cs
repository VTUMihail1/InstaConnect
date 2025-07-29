using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly PostsContext _postsContext;
    private readonly IUserQueryFactory _userQueryFactory;
    private readonly IApplicationMapper _applicationMapper;
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public UserRepository(
        PostsContext postsContext,
        IUserQueryFactory userQueryFactory,
        IApplicationMapper applicationMapper,
        ISqlConnectionFactory sqlConnectionFactory)
    {
        _postsContext = postsContext;
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

    public void Add(User user)
    {
        _postsContext
            .Users
            .Add(user);
    }

    public void Update(User user)
    {
        _postsContext
            .Users
            .Update(user);
    }

    public void Delete(User user)
    {
        _postsContext
            .Users
            .Remove(user);
    }
}
