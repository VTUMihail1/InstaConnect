using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.AddApiRequest;

public class AddUserEventRequestBuilder
{
    private readonly ObjectBuilder<UserAddedEventRequest> _objectBuilder;

    public AddUserEventRequestBuilder(ObjectBuilder<UserAddedEventRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(UserDataFaker.GetId());
        WithName(UserDataFaker.GetName());
        WithFirstName(UserDataFaker.GetFirstName());
        WithLastName(UserDataFaker.GetLastName());
        WithEmail(UserDataFaker.GetEmail());
        WithProfileImage(UserDataFaker.GetProfileImage());
    }

    public AddUserEventRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public AddUserEventRequestBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Name, name, transformer);

        return this;
    }

    public AddUserEventRequestBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.FirstName, firstName, transformer);

        return this;

    }

    public AddUserEventRequestBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.LastName, lastName, transformer);

        return this;
    }

    public AddUserEventRequestBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Email, email, transformer);

        return this;
    }

    public AddUserEventRequestBuilder WithProfileImage(string profileImage, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.ProfileImage, profileImage, transformer);

        return this;
    }

    public UserAddedEventRequest Create()
    {
        return _objectBuilder.Create();
    }
}
