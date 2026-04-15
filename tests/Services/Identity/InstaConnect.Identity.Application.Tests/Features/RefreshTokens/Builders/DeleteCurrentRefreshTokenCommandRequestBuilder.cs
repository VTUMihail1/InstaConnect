using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Identity.Application.Tests.Features.RefreshTokens.Builders;

public class DeleteCurrentRefreshTokenCommandRequestBuilder
{
    private string _id;
    private string _value;

    public DeleteCurrentRefreshTokenCommandRequestBuilder(RefreshToken refreshToken)
    {
        _id = refreshToken.Id.Id.Id;
        _value = refreshToken.Id.Value;
    }

    public DeleteCurrentRefreshTokenCommandRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id.Id);

        return this;
    }

    public DeleteCurrentRefreshTokenCommandRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public DeleteCurrentRefreshTokenCommandRequestBuilder WithValue(IStringTransformer transformer)
    {
        _value = transformer.Transform(_value);

        return this;
    }

    public DeleteCurrentRefreshTokenCommandRequest Build()
    {
        return new(_id, _value);
    }
}
