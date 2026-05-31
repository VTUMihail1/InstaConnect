namespace InstaConnect.Posts.Infrastructure.Tests.Features.Users.Builders;

public class UserDeletedEventRequestBuilder
{
	private string _id;
	private readonly string _name;
	private readonly string _firstName;
	private readonly string _lastName;
	private readonly string _email;
	private readonly string? _profileImage;
	private readonly DateTimeOffset _createdAtUtc;
	private readonly DateTimeOffset _updatedAtUtc;

	public UserDeletedEventRequestBuilder(User user)
	{
		_id = user.Id.Id;
		_name = UserDataFaker.GetName();
		_firstName = UserDataFaker.GetFirstName();
		_lastName = UserDataFaker.GetLastName();
		_email = UserDataFaker.GetEmail();
		_profileImage = UserDataFaker.GetProfileImage();
		_createdAtUtc = UserDataFaker.GetCreatedAtUtc();
		_updatedAtUtc = UserDataFaker.GetUpdatedAtUtc();
	}

	public UserDeletedEventRequestBuilder WithId(UserId id, IStringTransformer? transformer = null)
	{
		_id = transformer.TryTransform(id.Id);

		return this;
	}

	public UserDeletedEventRequestBuilder WithId(IStringTransformer transformer)
	{
		_id = transformer.Transform(_id);

		return this;
	}

	public UserDeletedEventRequest Build()
	{
		return new(new(_id, _name, _email, _firstName, _lastName, _profileImage, _createdAtUtc, _updatedAtUtc));
	}
}
