using InstaConnect.Identity.Application.Features.UserClaims.Models;
using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
    extension(IServiceScope serviceScope)
    {
        public async Task<UserClaim?> GetUserClaimByIdAsync(
        UserClaimIdCommandResponse id,
        CancellationToken cancellationToken)
        {
            return await serviceScope.GetUserClaimByIdAsync(
                new UserClaimId(new(id.Id), id.Claim),
                cancellationToken);
        }
    }
}
