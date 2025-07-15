using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Infrastructure;

using MassTransit.Testing;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Users.Utilities;

public abstract class BaseUserFunctionalTest : IClassFixture<PostWebApplicationFactory>, IAsyncLifetime
{
    protected ITestHarness TestHarness
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var testHarness = serviceScope.ServiceProvider.GetTestHarness();

            return testHarness;
        }
    }

    protected IUserRepository UserWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserRepository>();

            return userRepository;
        }
    }

    protected IServiceScope ServiceScope { get; }

    protected CancellationToken CancellationToken { get; }

    protected Dictionary<string, object> ValidJwtConfig { get; set; }

    protected BaseUserFunctionalTest(PostWebApplicationFactory functionalTestWebAppFactory)
    {
        ServiceScope = functionalTestWebAppFactory.Services.CreateScope();
        CancellationToken = new();
        ValidJwtConfig = [];
    }

    private async Task<User> CreateUserUtilAsync(CancellationToken cancellationToken)
    {
        var user = new User(
            DataFaker.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            DataFaker.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            DataFaker.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            DataFaker.GetAverageString(UserConfigurations.ProfileImageMaxLength, UserConfigurations.ProfileImageMinLength));

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserRepository>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }

    protected async Task<User> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserUtilAsync(cancellationToken);

        return user;
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

        if (await dbContext.Users.AnyAsync(CancellationToken))
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
