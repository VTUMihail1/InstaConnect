using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Builders;

public class AddUserCommandRequestBuilder
{
    private string _id;
    private string _name;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string? _profileImage;

    public AddUserCommandRequestBuilder()
    {
        _id = UserDataFaker.GetId();
        _name = UserDataFaker.GetName();
        _firstName = UserDataFaker.GetFirstName();
        _lastName = UserDataFaker.GetLastName();
        _email = UserDataFaker.GetEmail();
        _profileImage = UserDataFaker.GetProfileImage();
    }

    public AddUserCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public AddUserCommandRequestBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _name = transformer.TryTransform(name);

        return this;
    }

    public AddUserCommandRequestBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _firstName = transformer.TryTransform(firstName);

        return this;
    }

    public AddUserCommandRequestBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _lastName = transformer.TryTransform(lastName);

        return this;
    }

    public AddUserCommandRequestBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _email = transformer.TryTransform(email);

        return this;
    }

    public AddUserCommandRequestBuilder WithProfileImage(string? profileImage, IStringTransformer? transformer = null)
    {
        _profileImage = transformer.TryTransform(profileImage!);

        return this;
    }

    public AddUserCommandRequest Build()
    {
        return new(_id, _firstName, _lastName, _name, _email, _profileImage);
    }
}
