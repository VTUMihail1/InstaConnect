namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class DeleteCurrentUserCommandRequestBuilder
{
	private string _id;

	public DeleteCurrentUserCommandRequestBuilder(User user)
	{
		_id = user.Id.Id;
	}

	public DeleteCurrentUserCommandRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeleteCurrentUserCommandRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeleteCurrentUserCommandRequest Build()
	{
		return new(_id);
	}
}
