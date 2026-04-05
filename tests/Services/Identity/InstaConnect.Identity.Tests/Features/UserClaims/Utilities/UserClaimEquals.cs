using InstaConnect.Common.Events.Models;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;
using InstaConnect.Identity.Events.Features.UserClaims;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimEquals
{
    extension(UserClaimAddedEventRequest request)
    {
        public bool Matches(UserClaim entity)
        {
            return entity.Matches(request.UserClaim);
        }
    }

    extension(UserClaimDeletedEventRequest request)
    {
        public bool Matches(UserClaim entity)
        {
            return entity.Matches(request.UserClaim);
        }
    }

    extension(UserClaimEventRequest r)
    {
        public bool Matches(UserClaimEventRequest request)
        {
            return r.Id == request.Id &&
                   r.Claim == request.Claim &&
                   r.User.Matches(request.User) &&
                   r.CreatedAtUtc == request.CreatedAtUtc;
        }
    }

    extension(UserClaim entity)
    {
        public bool Matches(UserClaimEventRequest request)
        {
            return entity.Id.Matches(request.Id, request.Claim) &&
                   entity.User != null && entity.User.Matches(request.User) &&
                   entity.CreatedAtUtc == request.CreatedAtUtc;
        }

        public bool Matches(UserClaim e)
        {
            return entity.Id.Matches(e.Id.Id.Id, e.Id.Claim) &&
                   entity.CreatedAtUtc == e.CreatedAtUtc;
        }
    }

    extension(UserClaimId p)
    {
        public bool Matches(string id, ApplicationClaims claim)
        {
            return p.Id.Matches(id) &&
                   p.Claim == claim;
        }
    }
}
