using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;
internal interface IUserCollectionFactory
{
    UserCollection Create(ICollection<User> users, int totalCount, CommonPaginationQuery pagination);
}
