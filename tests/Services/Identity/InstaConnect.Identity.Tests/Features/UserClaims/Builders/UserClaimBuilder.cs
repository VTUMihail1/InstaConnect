using InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Builders;

public class UserClaimBuilder
{
    private string _id;
    private string _claim;
    private DateTimeOffset _createdAtUtc;

    public UserClaimBuilder(User user)
    {
        _id = user.Id.Id;
        _claim = UserClaimDataFaker.GetClaim();
        _createdAtUtc = UserClaimDataFaker.GetCreatedAtUtc();
    }

    public UserClaimBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public UserClaimBuilder WithClaim(IStringTransformer transformer)
    {
        _claim = transformer.Transform(_claim);

        return this;
    }

    public UserClaimBuilder WithCreatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _createdAtUtc = transformer.Transform(_createdAtUtc);

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
