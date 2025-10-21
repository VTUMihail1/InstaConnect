using InstaConnect.UserClaims.Domain.Features.UserClaims.Models.Requests;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IUserClaimIncludePropertyFactory
{
    ICollection<IUserClaimIncludeProperty> Create(ICollection<UserClaimIncludeProperty>? includeProperties);
}
