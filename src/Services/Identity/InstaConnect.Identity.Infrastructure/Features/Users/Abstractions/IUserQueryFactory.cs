using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Users.Infrastructure.Features.Users.Models;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;
public interface IUserQueryFactory
{
    GetAllUsersQuerySpecification CreateGetAll(GetAllUsersQuery query);
    GetAllUsersTotalCountQuerySpecification CreateGetAllTotalCount(UserFilterQuery query);
    GetUserByIdQuerySpecification CreateGetById(string id);
    GetUserByNameQuerySpecification CreateGetByName(string name);
    GetUserByEmailQuerySpecification CreateGetByEmail(string email);
}
