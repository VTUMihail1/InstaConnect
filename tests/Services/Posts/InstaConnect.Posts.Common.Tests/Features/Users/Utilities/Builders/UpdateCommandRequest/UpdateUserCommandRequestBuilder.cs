using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;
using InstaConnect.Users.Application.Features.Users.Commands.Add;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.UpdateApiRequest;

public class UpdateUserCommandRequestBuilder
{
    private readonly ObjectBuilder<UpdateUserCommandRequest> _objectBuilder;

    public UpdateUserCommandRequestBuilder(ObjectBuilder<UpdateUserCommandRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(UserDataFaker.GetId());
        WithName(UserDataFaker.GetName());
        WithFirstName(UserDataFaker.GetFirstName());
        WithLastName(UserDataFaker.GetLastName());
        WithEmail(UserDataFaker.GetEmail());
        WithProfileImage(UserDataFaker.GetProfileImage());
    }

    public UpdateUserCommandRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Name, name, transformer);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.FirstName, firstName, transformer);

        return this;

    }

    public UpdateUserCommandRequestBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.LastName, lastName, transformer);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Email, email, transformer);

        return this;
    }

    public UpdateUserCommandRequestBuilder WithProfileImage(string profileImage, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.ProfileImage, profileImage, transformer);

        return this;
    }

    public UpdateUserCommandRequest Create()
    {
        return _objectBuilder.Create();
    }
}
