using InstaConnect.Posts.Common.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Features.Users.Abstract;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Posts.Infrastructure;
using InstaConnect.Posts.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Application.Abstractions;
using MassTransit.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Users.Utilities;

public abstract class BaseUserFunctionalTest : IClassFixture<FunctionalTestWebAppFactory>, IAsyncLifetime
{
    protected ITestHarness TestHarness
    {
        get
        {
            using var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var testHarness = serviceScope.ServiceProvider.GetTestHarness();

            return testHarness;
        }
    }

    protected IUserWriteRepository UserWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

            return userRepository;
        }
    }

    protected IServiceScope ServiceScope { get; }

    protected CancellationToken CancellationToken { get; }

    protected Dictionary<string, object> ValidJwtConfig { get; set; }

    protected BaseUserFunctionalTest(FunctionalTestWebAppFactory followsFunctionalTestWebAppFactory)
    {
        ServiceScope = followsFunctionalTestWebAppFactory.Services.CreateScope();
        CancellationToken = new();
        ValidJwtConfig = [];
    }

    protected async Task<string> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidEmail,
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidProfileImage);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    public async Task InitializeAsync()
    {
        await TestHarness.Start();
        await EnsureDatabaseIsEmpty();
    }

    public async Task DisposeAsync()
    {
        await TestHarness.Stop();
        await EnsureDatabaseIsEmpty();
    }

    private async Task EnsureDatabaseIsEmpty()
    {
        var dbContext = ServiceScope.ServiceProvider.GetRequiredService<PostsContext>();

        if (dbContext.Users.Any())
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
