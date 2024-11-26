using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentUser;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Queries;

public class GetCurrentUserQueryHandlerIntegrationTests : BaseUserIntegrationTest
{
    public GetCurrentUserQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(null!);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(UserTestUtilities.InvalidId);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<UserNotFoundException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(existingUserId);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryViewModel>(m => m.Id == existingUserId &&
                                          m.UserName == UserTestUtilities.ValidName &&
                                          m.FirstName == UserTestUtilities.ValidFirstName &&
                                          m.LastName == UserTestUtilities.ValidLastName &&
                                          m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(SharedTestUtilities.GetNonCaseMatchingString(existingUserId));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryViewModel>(m => m.Id == existingUserId &&
                                          m.UserName == UserTestUtilities.ValidName &&
                                          m.FirstName == UserTestUtilities.ValidFirstName &&
                                          m.LastName == UserTestUtilities.ValidLastName &&
                                          m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task SendAsync_ShouldSaveUserViewModelCollectionToCacheService_WhenQueryIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentUserQuery(existingUserId);

        // Act
        await InstaConnectSender.SendAsync(query, CancellationToken);

        var result = await CacheHandler.GetAsync<UserQueryViewModel>(query.Key, CancellationToken);

        // Assert
        result
            .Should()
            .Match<UserQueryViewModel>(m => m.Id == existingUserId &&
                                          m.UserName == UserTestUtilities.ValidName &&
                                          m.FirstName == UserTestUtilities.ValidFirstName &&
                                          m.LastName == UserTestUtilities.ValidLastName &&
                                          m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
