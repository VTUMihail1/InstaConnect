using InstaConnect.Common.Domain.Utilities;
using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Builders;

public class UserClaimBuilder
{
    private string _id;
    private ApplicationClaims _claim;
    private DateTimeOffset _createdAtUtc;

    public UserClaimBuilder(User user)
    {
        _id = user.Id.Id;
        _claim = UserClaimDataFaker.GetClaim();
        _createdAtUtc = UserClaimDataFaker.GetCreatedAtUtc();
    }

    public UserClaimBuilder WithId(string id)
    {
        _id = id;

        return this;
    }

    public UserClaimBuilder WithClaim(ApplicationClaims claim)
    {
        _claim = claim;

        return this;
    }

    public UserClaimBuilder WithCreatedAtUtc(DateTimeOffset createdAtUtc)
    {
        _createdAtUtc = createdAtUtc;

        return this;
    }

    public UserClaim Build()
    {
        return new(
            new(
                new(_id),
                _claim),
            _createdAtUtc);
    }
}
