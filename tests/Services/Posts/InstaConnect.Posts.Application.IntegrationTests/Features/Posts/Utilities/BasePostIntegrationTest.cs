using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Posts.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Utilities;

public abstract class BasePostIntegrationTest : PostWebTest
{
    protected IApplicationSender ApplicationSender { get; }

    protected BasePostIntegrationTest(PostsWebApplicationFactory postsWebApplicationFactory) : base(postsWebApplicationFactory)
    {
        ApplicationSender = ServiceScope.GetApplicationSender();
    }
}
