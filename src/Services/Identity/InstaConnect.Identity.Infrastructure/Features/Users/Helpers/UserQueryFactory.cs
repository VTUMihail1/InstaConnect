using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Models;
using InstaConnect.Users.Infrastructure.Features.Users.Utilities;

namespace InstaConnect.Users.Infrastructure.Features.Users.Helpers;

public class UserQueryFactory : IUserQueryFactory
{
    private readonly IPaginator _paginator;
    private readonly ISortOrderFactory _sortOrderFactory;
    private readonly IUserSortPropertyFactory _userSortPropertyFactory;

    public UserQueryFactory(
        IPaginator paginator,
        ISortOrderFactory sortOrderFactory,
        IUserSortPropertyFactory userSortPropertyFactory)
    {
        _paginator = paginator;
        _sortOrderFactory = sortOrderFactory;
        _userSortPropertyFactory = userSortPropertyFactory;
    }

    public GetAllUsersQuerySpecification CreateGetAll(GetAllUsersQuery query)
    {
        var sortOrder = _sortOrderFactory.Create(query.Sorting.Order);
        var sortProperty = _userSortPropertyFactory.Create(query.Sorting.Property);
        var offset = _paginator.GetOffset(query.Pagination.Page, query.Pagination.PageSize);
        var parameters = new GetAllUsersQueryParameters(
            query.Filter.FirstName,
            query.Filter.LastName,
            query.Filter.Name,
            sortOrder.Order,
            sortProperty.Property,
            offset,
            query.Pagination.PageSize);

        var specification = new GetAllUsersQuerySpecification(
            UserQuerySql.GetAll,
            parameters);

        return specification;
    }

    public GetAllUsersTotalCountQuerySpecification CreateGetAllTotalCount(UserFilterQuery query)
    {
        var parameters = new GetAllUsersTotalCountQueryParameters(
            query.FirstName,
            query.LastName,
            query.Name);

        var specification = new GetAllUsersTotalCountQuerySpecification(
            UserQuerySql.GetAllTotalCount,
            parameters);

        return specification;
    }

    public GetUserByIdQuerySpecification CreateGetById(string id)
    {
        var parameters = new GetUserByIdQueryParameters(id);

        var result = new GetUserByIdQuerySpecification(
            UserQuerySql.GetById,
            parameters);

        return result;
    }

    public GetUserByNameQuerySpecification CreateGetByName(string name)
    {
        var parameters = new GetUserByNameQueryParameters(name);

        var result = new GetUserByNameQuerySpecification(
            UserQuerySql.GetByName,
            parameters);

        return result;
    }

    public GetUserByEmailQuerySpecification CreateGetByEmail(string email)
    {
        var parameters = new GetUserByEmailQueryParameters(email);

        var result = new GetUserByEmailQuerySpecification(
            UserQuerySql.GetByEmail,
            parameters);

        return result;
    }
}
