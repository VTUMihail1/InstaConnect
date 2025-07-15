using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Posts.Common.Tests.Features.Posts.Utilities.Builders;
using InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Posts.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Posts.Common.Tests.Features.Posts.Utilities;

public abstract class PostWebTest : IClassFixture<PostWebApplicationFactory>, IAsyncLifetime
{
    protected IServiceScope ServiceScope { get; }

    protected CancellationToken CancellationToken { get; }

    protected PostWebTest(PostWebApplicationFactory webApplicationFactory)
    {
        ServiceScope = webApplicationFactory.Services.CreateScope();
        CancellationToken = MockFactory.CreateCancellationToken();
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
