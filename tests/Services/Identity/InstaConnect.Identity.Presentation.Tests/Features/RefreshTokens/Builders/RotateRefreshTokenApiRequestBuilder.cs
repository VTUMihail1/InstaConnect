namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Builders;

public class RotateRefreshTokenApiRequestBuilder
{
    private string _id;
    private string _value;

    public RotateRefreshTokenApiRequestBuilder(RefreshToken refreshToken)
    {
        _id = refreshToken.Id.Id.Id;
        _value = refreshToken.Id.Value;
    }

    public RotateRefreshTokenApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public RotateRefreshTokenApiRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public RotateRefreshTokenApiRequestBuilder WithValue(IStringTransformer transformer)
    {
        _value = transformer.Transform(_value);

        return this;
    }

    public RotateRefreshTokenApiRequest Build()
    {
        return new(_id, _value);
    }
}
