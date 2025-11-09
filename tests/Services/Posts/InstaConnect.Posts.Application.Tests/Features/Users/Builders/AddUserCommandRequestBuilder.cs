namespace InstaConnect.Posts.Application.Tests.Features.Users.Builders;

public class AddUserCommandRequestBuilder
{
    private readonly ObjectBuilder<AddUserCommandRequest> _objectBuilder;

    public AddUserCommandRequestBuilder(ObjectBuilder<AddUserCommandRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(UserDataFaker.GetId());
        WithName(UserDataFaker.GetName());
        WithFirstName(UserDataFaker.GetFirstName());
        WithLastName(UserDataFaker.GetLastName());
        WithEmail(UserDataFaker.GetEmail());
        WithProfileImage(UserDataFaker.GetProfileImage());
    }

    public AddUserCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public AddUserCommandRequestBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Name, name, transformer);

        return this;
    }

    public AddUserCommandRequestBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.FirstName, firstName, transformer);

        return this;

    }

    public AddUserCommandRequestBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.LastName, lastName, transformer);

        return this;
    }

    public AddUserCommandRequestBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Email, email, transformer);

        return this;
    }

    public AddUserCommandRequestBuilder WithProfileImage(string? profileImage, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.ProfileImage, profileImage, transformer);

        return this;
    }

    public AddUserCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
