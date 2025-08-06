using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.DeleteApiRequest;

public class UserDeletedEventRequestBuilder
{
    private readonly ObjectBuilder<UserDeletedEventRequest> _objectBuilder;

    public UserDeletedEventRequestBuilder(ObjectBuilder<UserDeletedEventRequest> objectBuilder, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(user.Id);
    }

    public UserDeletedEventRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public UserDeletedEventRequest Create()
    {
        return _objectBuilder.Create();
    }
}
