namespace InstaConnect.Posts.Application.Tests.Features.Users.Builders;

public class UpdateUserCommandRequestBuilder
{
    private readonly ObjectBuilder<UpdateUserCommandRequest> _objectBuilder;

    public UpdateUserCommandRequestBuilder(ObjectBuilder<UpdateUserCommandRequest> objectBuilder, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(user.Id);
        WithName(UserDataFaker.GetName());
        WithFirstName(UserDataFaker.GetFirstName());
        WithLastName(UserDataFaker.GetLastName());
        WithEmail(UserDataFaker.GetEmail());
        WithProfileImage(UserDataFaker.GetProfileImage());
    }

    public UpdateUserCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Name, name, transformer);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.FirstName, firstName, transformer);

        return this;

    }

    public UpdateUserCommandRequestBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.LastName, lastName, transformer);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Email, email, transformer);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithProfileImage(string? profileImage, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.ProfileImage, profileImage, transformer);

        return this;
    }

    public UpdateUserCommandRequest Build()
    {
        return _objectBuilder.Build();
    }
}
