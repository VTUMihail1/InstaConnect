namespace InstaConnect.Chats.Domain.Tests.Features.Users.Builders;

public class DeleteUserCommandBuilder
{
	private string _id;

	public DeleteUserCommandBuilder(User user)
	{
		_id = user.Id.Id;
	}

	public DeleteUserCommandBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public DeleteUserCommandBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public DeleteUserCommand Build()
	{
		return new(
			new(_id));
	}
}
