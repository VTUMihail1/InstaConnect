﻿using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Infrastructure;
using InstaConnect.Shared.Application.Abstractions;

using MassTransit.Testing;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.EmailConfirmationTokens.Utilities;

public abstract class BaseEmailConfirmationTokenIntegrationTest : IClassFixture<IdentityWebApplicationFactory>, IAsyncLifetime
{
    protected IServiceScope ServiceScope { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected ITestHarness TestHarness
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var testHarness = serviceScope.ServiceProvider.GetTestHarness();

            return testHarness;
        }
    }

    protected IEmailConfirmationTokenWriteRepository EmailConfirmationTokenWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var emailConfirmationTokenWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IEmailConfirmationTokenWriteRepository>();

            return emailConfirmationTokenWriteRepository;
        }
    }

    protected IForgotPasswordTokenWriteRepository ForgotPasswordTokenWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var forgotPasswordTokenWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IForgotPasswordTokenWriteRepository>();

            return forgotPasswordTokenWriteRepository;
        }
    }

    protected IUserClaimWriteRepository UserClaimWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userClaimWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IUserClaimWriteRepository>();

            return userClaimWriteRepository;
        }
    }

    protected IUserWriteRepository UserWriteRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userWriteRepository = serviceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();

            return userWriteRepository;
        }
    }

    protected IUserReadRepository UserReadRepository
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var userReadRepository = serviceScope.ServiceProvider.GetRequiredService<IUserReadRepository>();

            return userReadRepository;
        }
    }

    protected ICacheHandler CacheHandler
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var cacheHandlerRepository = serviceScope.ServiceProvider.GetRequiredService<ICacheHandler>();

            return cacheHandlerRepository;
        }
    }

    protected IPasswordHasher PasswordHasher { get; }


    protected BaseEmailConfirmationTokenIntegrationTest(IdentityWebApplicationFactory integrationTestWebAppFactory)
    {
        ServiceScope = integrationTestWebAppFactory.Services.CreateScope();
        CancellationToken = new CancellationToken();
        InstaConnectSender = ServiceScope.ServiceProvider.GetRequiredService<IInstaConnectSender>();
        PasswordHasher = ServiceScope.ServiceProvider.GetRequiredService<IPasswordHasher>();
    }

    private async Task<User> CreateUserUtilAsync(bool isEmailConfirmed, CancellationToken cancellationToken)
    {
        var passwordHasher = ServiceScope.ServiceProvider.GetRequiredService<IPasswordHasher>();
        var passwordHash = passwordHasher.Hash(UserTestUtilities.ValidPassword).PasswordHash;

        var user = new User(
            SharedTestUtilities.GetAverageString(UserConfigurations.FirstNameMaxLength, UserConfigurations.FirstNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.LastNameMaxLength, UserConfigurations.LastNameMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.EmailMaxLength, UserConfigurations.EmailMinLength),
            SharedTestUtilities.GetAverageString(UserConfigurations.NameMaxLength, UserConfigurations.NameMinLength),
            passwordHash,
            UserTestUtilities.ValidProfileImage)
        {
            IsEmailConfirmed = isEmailConfirmed
        };

        var userWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IUserWriteRepository>();
        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        userWriteRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }

    protected async Task<User> CreateUserAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserUtilAsync(false, cancellationToken);

        return user;
    }

    protected async Task<User> CreateUserWithConfirmedEmailAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserUtilAsync(true, cancellationToken);

        return user;
    }

    private async Task<EmailConfirmationToken> CreateEmailConfirmationTokenUtilAsync(
        User user,
        CancellationToken cancellationToken)
    {
        var emailConfirmationToken = new EmailConfirmationToken(
            SharedTestUtilities.GetGuid(),
            SharedTestUtilities.GetMaxDate(),
            user);

        var unitOfWork = ServiceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var emailConfirmationTokenWriteRepository = ServiceScope.ServiceProvider.GetRequiredService<IEmailConfirmationTokenWriteRepository>();

        emailConfirmationTokenWriteRepository.Add(emailConfirmationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return emailConfirmationToken;
    }

    protected async Task<EmailConfirmationToken> CreateEmailConfirmationTokenAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserAsync(cancellationToken);
        var emailConfirmationToken = await CreateEmailConfirmationTokenUtilAsync(user, cancellationToken);

        return emailConfirmationToken;
    }

    protected async Task<EmailConfirmationToken> CreateEmailConfirmationTokenWithConfirmedUserEmailAsync(CancellationToken cancellationToken)
    {
        var user = await CreateUserWithConfirmedEmailAsync(cancellationToken);
        var emailConfirmationToken = await CreateEmailConfirmationTokenUtilAsync(user, cancellationToken);

        return emailConfirmationToken;
    }

    public async Task InitializeAsync()
    {
        await EnsureDatabaseIsEmptyAsync();
    }

    public async Task DisposeAsync()
    {
        await EnsureDatabaseIsEmptyAsync();
    }

    private async Task EnsureDatabaseIsEmptyAsync()
    {
        var dbContext = ServiceScope.ServiceProvider.GetRequiredService<IdentityContext>();

        if (await dbContext.EmailConfirmationTokens.AnyAsync(CancellationToken))
        {
            await dbContext.EmailConfirmationTokens.ExecuteDeleteAsync(CancellationToken);
        }

        if (await dbContext.UserClaims.AnyAsync(CancellationToken))
        {
            await dbContext.UserClaims.ExecuteDeleteAsync(CancellationToken);
        }

        if (await dbContext.Users.AnyAsync(CancellationToken))
        {
            await dbContext.Users.ExecuteDeleteAsync(CancellationToken);
        }
    }
}
