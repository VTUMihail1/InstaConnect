using InstaConnect.Common.Tests.DataAttributes.Base;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Builders;

public class UpdateUserCommandRequestBuilder
{
    private string _id;
    private string _name;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string? _profileImage;

    public UpdateUserCommandRequestBuilder(User user)
    {
        _id = user.Id;
        _name = UserDataFaker.GetName();
        _firstName = UserDataFaker.GetFirstName();
        _lastName = UserDataFaker.GetLastName();
        _email = UserDataFaker.GetEmail();
        _profileImage = UserDataFaker.GetProfileImage();
    }

    public UpdateUserCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _name = transformer.TryTransform(name);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _firstName = transformer.TryTransform(firstName);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _lastName = transformer.TryTransform(lastName);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _email = transformer.TryTransform(email);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithProfileImage(string? profileImage, IStringTransformer? transformer = null)
    {
        _profileImage = transformer.TryTransform(profileImage!);

        return this;
    }

    public UpdateUserCommandRequest Build()
    {
        return new(_id, _firstName, _lastName, _name, _email, _profileImage);
    }
}
