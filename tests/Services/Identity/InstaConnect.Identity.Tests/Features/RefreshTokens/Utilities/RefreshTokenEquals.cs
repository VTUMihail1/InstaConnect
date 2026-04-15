using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
using InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.RefreshTokens.Utilities;

public static class RefreshTokenEquals
{
    extension(RefreshTokenId p)
    {
        public bool Matches(string id, string value)
        {
            return p.Id.Matches(id) &&
                   p.Value.EqualsOrdinalIgnoreCase(value);
        }
    }
}
