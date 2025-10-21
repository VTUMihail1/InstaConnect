using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Users.Infrastructure.Features.Users.Abstractions;
internal interface IUserCollectionFactory
{
    UserCollection Create(ICollection<User> users, int totalCount, UserPaginationQuery pagination);
}
