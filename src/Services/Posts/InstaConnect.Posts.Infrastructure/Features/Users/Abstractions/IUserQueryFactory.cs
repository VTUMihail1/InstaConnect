using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Abstractions;
public interface IUserQueryFactory
{
    GetUserByIdSpecification CreateGetById(string id);

    GetUserByNameSpecification CreateGetByName(string name);

    GetUserByEmailSpecification CreateGetByEmail(string email);
}
