using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders.AddApiRequest;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Common.Tests.Features.Users.Utilities.Builders.AddApiRequest;

using Mapster;

using MapsterMapper;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Utilities;

public abstract class BasePostApplicationUnitTest : BasePostTest
{
    protected IApplicationMapper ApplicationMapper { get; }

    protected IPostService PostService { get; }

    protected BasePostApplicationUnitTest()
    {
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostApplicationReference.Assembly);
        PostService = PostMockFactory.CreateService();
    }
}
