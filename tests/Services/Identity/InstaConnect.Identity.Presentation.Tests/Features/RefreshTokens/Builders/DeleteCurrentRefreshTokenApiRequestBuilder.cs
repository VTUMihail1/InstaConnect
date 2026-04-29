namespace InstaConnect.Identity.Presentation.Tests.Features.RefreshTokens.Builders;

public class DeleteCurrentRefreshTokenApiRequestBuilder
{
	private string _id;
	private string _value;

	public DeleteCurrentRefreshTokenApiRequestBuilder(RefreshToken refreshToken)
	{
		_id = refreshToken.Id.Id.Id;
		_value = refreshToken.Id.Value;
	}

	public DeleteCurrentRefreshTokenApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeleteCurrentRefreshTokenApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeleteCurrentRefreshTokenApiRequestBuilder WithValue(IStringTransformer transformer)
	{
		_value = transformer.Transform(_value);

		return this;
	}

	public DeleteCurrentRefreshTokenApiRequest Build()
	{
		return new(_id, _value);
	}
}
