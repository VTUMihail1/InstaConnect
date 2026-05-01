namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class DeleteUserApiRequestBuilder
{
	private string _id;

	public DeleteUserApiRequestBuilder(User user)
	{
		_id = user.Id.Id;
	}

	public DeleteUserApiRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeleteUserApiRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeleteUserApiRequest Build()
	{
		return new(_id);
	}
}
