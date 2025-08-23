using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.UpdateApiRequest;

public class UserUpdatedEventRequestBuilder
{
    private readonly ObjectBuilder<UserUpdatedEventRequest> _objectBuilder;

    public UserUpdatedEventRequestBuilder(ObjectBuilder<UserUpdatedEventRequest> objectBuilder, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(user.Id);
        WithName(UserDataFaker.GetName());
        WithFirstName(UserDataFaker.GetFirstName());
        WithLastName(UserDataFaker.GetLastName());
        WithEmail(UserDataFaker.GetEmail());
        WithProfileImage(UserDataFaker.GetProfileImage());
    }

    public UserUpdatedEventRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Name, name, transformer);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.FirstName, firstName, transformer);

        return this;

    }

    public UserUpdatedEventRequestBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.LastName, lastName, transformer);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Email, email, transformer);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithProfileImage(string? profileImage, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.ProfileImage, profileImage, transformer);

        return this;
    }

    public UserUpdatedEventRequest Build()
    {
        return _objectBuilder.Build();
    }
}
