namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Builders;

public class RotateRefreshTokenCommandRequestBuilder
{
    private string _id;
    private string _value;

    public RotateRefreshTokenCommandRequestBuilder(RefreshToken refreshToken)
    {
        _id = refreshToken.Id.Id.Id;
        _value = refreshToken.Id.Value;
    }

    public RotateRefreshTokenCommandRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public RotateRefreshTokenCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public RotateRefreshTokenCommandRequestBuilder WithValue(IStringTransformer transformer)
    {
        _value = transformer.Transform(_value);

        return this;
    }

    public RotateRefreshTokenCommandRequest Build()
    {
        return new(_id, _value);
    }
}
