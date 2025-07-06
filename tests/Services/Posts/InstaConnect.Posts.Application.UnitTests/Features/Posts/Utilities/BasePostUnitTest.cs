using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Helpers;
using InstaConnect.Common.Helpers;
using InstaConnect.Posts.Application.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using Mapster;

using MapsterMapper;

namespace InstaConnect.Posts.Application.UnitTests.Features.Posts.Utilities;

public abstract class BasePostUnitTest
{
    protected CancellationToken CancellationToken { get; }

    protected IApplicationMapper ApplicationMapper { get; }

    protected IPostService PostService { get; }

    protected BasePostUnitTest()
    {
        CancellationToken = MockFactory.CreateCancellationToken();
        ApplicationMapper = MockFactory.CreateApplicationMapper(PostApplicationReference.Assembly);
        PostService = PostMockFactory.CreatePostService();
    }
}
