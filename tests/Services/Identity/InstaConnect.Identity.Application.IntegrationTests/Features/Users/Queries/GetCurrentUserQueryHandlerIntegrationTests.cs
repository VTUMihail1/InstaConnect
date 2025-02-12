using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrent;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Queries;

public class GetCurrentUserQueryHandlerIntegrationTests : BaseUserIntegrationTest
{
    public GetCurrentUserQueryHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(null);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(UserTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(existingUser.Id);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryViewModel>(m => m.Id == existingUser.Id &&
                                          m.UserName == existingUser.UserName &&
                                          m.FirstName == existingUser.FirstName &&
                                          m.LastName == existingUser.LastName &&
                                          m.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(SharedTestUtilities.GetNonCaseMatchingString(existingUser.Id));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryViewModel>(m => m.Id == existingUser.Id &&
                                          m.UserName == existingUser.UserName &&
                                          m.FirstName == existingUser.FirstName &&
                                          m.LastName == existingUser.LastName &&
                                          m.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldSaveUserViewModelCollectionToCacheService_WhenQueryIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(existingUser.Id);

        // Act
        await InstaConnectSender.SendAsync(query, CancellationToken);

        var result = await CacheHandler.GetAsync<UserQueryViewModel>(query.Key, CancellationToken);

        // Assert
        result
            .Should()
            .Match<UserQueryViewModel>(m => m.Id == existingUser.Id &&
                                          m.UserName == existingUser.UserName &&
                                          m.FirstName == existingUser.FirstName &&
                                          m.LastName == existingUser.LastName &&
                                          m.ProfileImage == existingUser.ProfileImage);
    }
}
