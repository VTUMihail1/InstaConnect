namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserDeletedEventRequestBuilder
{
    private string _id;
    private string _name;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string? _profileImage;
    private DateTimeOffset _createdAtUtc;
    private DateTimeOffset _updatedAtUtc;

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

    public UserDeletedEventRequestBuilder WithId(User user, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(user.Id.Id);

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
