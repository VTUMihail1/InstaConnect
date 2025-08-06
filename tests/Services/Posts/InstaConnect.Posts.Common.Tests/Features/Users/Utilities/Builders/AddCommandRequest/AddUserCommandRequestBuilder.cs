using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Users.Application.Features.Users.Commands.Add;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.AddApiRequest;

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
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public AddUserCommandRequestBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Name, name, transformer);

        return this;
    }

    public AddUserCommandRequestBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.FirstName, firstName, transformer);

        return this;

    }

    public AddUserCommandRequestBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.LastName, lastName, transformer);

        return this;
    }

    public AddUserCommandRequestBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Email, email, transformer);

        return this;
    }

    public AddUserCommandRequestBuilder WithProfileImage(string? profileImage, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.ProfileImage, profileImage, transformer);

        return this;
    }

    public AddUserCommandRequest Create()
    {
        return _objectBuilder.Create();
    }
}
