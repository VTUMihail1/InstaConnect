using AutoMapper;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Extensions;

namespace InstaConnect.Posts.Presentation.UnitTests.Features.Posts.Utilities;

public abstract class BasePostUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected BasePostUnitTest()
    {
        CancellationToken = new();
        InstaConnectSender = Mocker.Mock<IInstaConnectSender>();
        InstaConnectMapper = new InstaConnectMapper(
            new Mapper(
                new MapperConfiguration(cfg => cfg.AddMaps(PostPresentationReference.Assembly))));
    }

    protected static Post SetupPost(User user)
    {
        var post = new PostBuilder(user).Create();

        return post;
    }

    protected static User SetupUser()
    {
        var user = new UserBuilder().Create();

        return user;
    }
}
