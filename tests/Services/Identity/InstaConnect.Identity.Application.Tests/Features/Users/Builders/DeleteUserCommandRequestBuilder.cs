namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class DeleteUserCommandRequestBuilder
{
	private string _id;

	public DeleteUserCommandRequestBuilder(User user)
	{
		_id = user.Id.Id;
	}

	public DeleteUserCommandRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeleteUserCommandRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeleteUserCommandRequest Build()
	{
		return new(_id);
	}
}
