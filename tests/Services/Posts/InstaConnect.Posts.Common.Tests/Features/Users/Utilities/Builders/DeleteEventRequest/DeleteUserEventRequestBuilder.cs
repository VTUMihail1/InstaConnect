using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.DataAttributes.Strings.Base;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.DeleteApiRequest;

public class DeleteUserEventRequestBuilder
{
    private readonly ObjectBuilder<UserDeletedEventRequest> _objectBuilder;

    public DeleteUserEventRequestBuilder(ObjectBuilder<UserDeletedEventRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(UserDataFaker.GetId());
    }

    public DeleteUserEventRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.With(p => p.Id, id, transformer);

        return this;
    }

    public UserDeletedEventRequest Create()
    {
        return _objectBuilder.Create();
    }
}
