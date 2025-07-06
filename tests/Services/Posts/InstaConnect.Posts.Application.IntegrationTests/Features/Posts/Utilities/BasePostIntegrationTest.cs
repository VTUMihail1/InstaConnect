using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Posts.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Application.IntegrationTests.Features.Posts.Utilities;

public abstract class BasePostIntegrationTest : IClassFixture<PostsWebApplicationFactory>, IAsyncLifetime
{
    protected IServiceScope ServiceScope { get; }

    protected CancellationToken CancellationToken { get; }

    protected IApplicationSender ApplicationSender { get; }

    protected BasePostIntegrationTest(PostsWebApplicationFactory postsWebApplicationFactory)
    {
        ServiceScope = postsWebApplicationFactory.Services.CreateScope();
        CancellationToken = MockFactory.CreateCancellationToken();
        ApplicationSender = ServiceScope.GetApplicationSender();
    }

    public async Task InitializeAsync()
    {
        await ServiceScope.ResetPostDatabase(CancellationToken);
        await OnInitializeAsync();
    }

    public async Task DisposeAsync()
    {
        await ServiceScope.ResetPostDatabase(CancellationToken);
    }

    protected abstract Task OnInitializeAsync();
}
