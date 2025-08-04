using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.AddApiRequest;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;

public class UserBuilderFactory
{
    private readonly ObjectBuilderFactory<User> _objectBuilderFactory = new();

    public UserBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var entityBuilder = new UserBuilder(objectBuilder);

        return entityBuilder;
    }
}
