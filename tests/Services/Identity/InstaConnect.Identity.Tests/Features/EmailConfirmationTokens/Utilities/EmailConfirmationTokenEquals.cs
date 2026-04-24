using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;
using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;

public static class EmailConfirmationTokenEquals
{
    extension(EmailConfirmationTokenAddedEventRequest request)
    {
        public bool Matches(EmailConfirmationToken entity)
        {
            return entity.Matches(request.EmailConfirmationToken);
        }
    }

    extension(EmailConfirmationTokenDeletedEventRequest request)
    {
        public bool Matches(EmailConfirmationToken entity)
        {
            return entity.Matches(request.EmailConfirmationToken);
        }
    }

    extension(EmailConfirmationTokenEventRequest r)
    {
        public bool Matches(EmailConfirmationTokenEventRequest request)
        {
            return r.Id == request.Id &&
                   r.Value == request.Value &&
                   r.User.Matches(request.User) &&
                   r.ExpiresAtUtc == request.ExpiresAtUtc &&
                   r.CreatedAtUtc == request.CreatedAtUtc;
        }
    }

    extension(EmailConfirmationToken entity)
    {
        public bool Matches(EmailConfirmationTokenEventRequest request)
        {
            return entity.Id.Matches(request.Id, request.Value) &&
                   entity.User != null && entity.User.Matches(request.User) &&
                   entity.ExpiresAtUtc == request.ExpiresAtUtc &&
                   entity.CreatedAtUtc == request.CreatedAtUtc;
        }

        public bool Matches(EmailConfirmationToken e)
        {
            return entity.Id.Matches(e.Id.Id.Id, e.Id.Value) &&
                   entity.ExpiresAtUtc == e.ExpiresAtUtc &&
                   entity.CreatedAtUtc == e.CreatedAtUtc;
        }
    }

    extension(EmailConfirmationTokenId p)
    {
        public bool Matches(string id, string value)
        {
            return p.Id.Matches(id) &&
                   p.Value.EqualsOrdinalIgnoreCase(value);
        }
    }

    extension(ICollection<EmailConfirmationToken> emailConfirmationTokens)
    {
        public bool Matches(
            ICollection<EmailConfirmationToken> e)
        {
            return emailConfirmationTokens.MatchesCollection(e,
                                                          e => e.Id,
                                                          e => e.Id,
                                                          (emailConfirmationToken, e) => emailConfirmationToken.Matches(e));
        }
    }
}
