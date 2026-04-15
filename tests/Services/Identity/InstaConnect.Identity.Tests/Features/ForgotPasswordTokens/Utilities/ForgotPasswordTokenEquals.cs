using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;
using InstaConnect.Identity.Events.Features.ForgotPasswordTokens;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenEquals
{
    extension(ForgotPasswordTokenAddedEventRequest request)
    {
        public bool Matches(ForgotPasswordToken entity)
        {
            return entity.Matches(request.ForgotPasswordToken);
        }
    }

    extension(ForgotPasswordTokenDeletedEventRequest request)
    {
        public bool Matches(ForgotPasswordToken entity)
        {
            return entity.Matches(request.ForgotPasswordToken);
        }
    }

    extension(ForgotPasswordTokenEventRequest r)
    {
        public bool Matches(ForgotPasswordTokenEventRequest request)
        {
            return r.Id == request.Id &&
                   r.Value == request.Value &&
                   r.User.Matches(request.User) &&
                   r.ExpiresAtUtc == request.ExpiresAtUtc &&
                   r.CreatedAtUtc == request.CreatedAtUtc;
        }
    }

    extension(ForgotPasswordToken entity)
    {
        public bool Matches(ForgotPasswordTokenEventRequest request)
        {
            return entity.Id.Matches(request.Id, request.Value) &&
                   entity.User != null && entity.User.Matches(request.User) &&
                   entity.ExpiresAtUtc == request.ExpiresAtUtc &&
                   entity.CreatedAtUtc == request.CreatedAtUtc;
        }

        public bool Matches(ForgotPasswordToken e)
        {
            return entity.Id.Matches(e.Id.Id.Id, e.Id.Value) &&
                   entity.ExpiresAtUtc == e.ExpiresAtUtc &&
                   entity.CreatedAtUtc == e.CreatedAtUtc;
        }
    }

    extension(ForgotPasswordTokenId p)
    {
        public bool Matches(string id, string value)
        {
            return p.Id.Matches(id) &&
                   p.Value.EqualsOrdinalIgnoreCase(value);
        }
    }

    extension(ICollection<ForgotPasswordToken> forgotPasswordTokens)
    {
        public bool Matches(
            ICollection<ForgotPasswordToken> f)
        {
            return forgotPasswordTokens.MatchesCollection(f,
                                                          f => f.Id,
                                                          f => f.Id,
                                                          (forgotPasswordToken, f) => forgotPasswordToken.Matches(f));
        }
    }
}
