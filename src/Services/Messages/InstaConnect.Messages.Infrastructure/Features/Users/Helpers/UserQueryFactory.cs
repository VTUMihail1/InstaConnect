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

    public GetUserByEmailSpecification CreateGetByEmail(string email)
    {
        var parameters = new GetUserByEmailParameters(email);

        var result = new GetUserByEmailSpecification(
            UserQuerySql.GetByEmail,
            parameters);

        return result;
    }

    public GetUserByNameSpecification CreateGetByName(string name)
    {
        var parameters = new GetUserByNameParameters(name);

        var result = new GetUserByNameSpecification(
            UserQuerySql.GetByName,
            parameters);

        return result;
    }
}
