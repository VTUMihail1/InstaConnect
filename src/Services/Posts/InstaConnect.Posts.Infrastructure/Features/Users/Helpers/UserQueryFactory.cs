using InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;

namespace InstaConnect.Users.Infrastructure.Features.Users.Helpers;

public class UserQueryFactory : IUserQueryFactory
{
    public GetUserByIdSpecification CreateGetById(string id)
    {
        var parameters = new GetUserByIdParameters(id);

        var result = new GetUserByIdSpecification(
            UserQuerySql.GetById,
            parameters);

        return result;
    }
}
