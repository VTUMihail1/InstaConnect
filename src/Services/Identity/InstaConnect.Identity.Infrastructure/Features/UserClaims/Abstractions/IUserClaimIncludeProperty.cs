using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.UserClaims.Domain.Features.UserClaims.Models.Requests;

namespace InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Abstractions;

public interface IUserClaimIncludeProperty : IIncludeProperty<UserClaim>
{
    public UserClaimIncludeProperty IncludeProperty { get; }
}
