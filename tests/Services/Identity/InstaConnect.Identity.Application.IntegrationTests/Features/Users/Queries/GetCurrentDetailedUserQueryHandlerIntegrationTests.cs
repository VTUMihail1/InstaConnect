using InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentDetailed;
using InstaConnect.Identity.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Queries;

public class GetCurrentDetailedUserQueryHandlerIntegrationTests : BaseUserIntegrationTest
{
    public GetCurrentDetailedUserQueryHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsNull()
    {
        // Arrange
        var query = new GetCurrentDetailedUserQuery(null);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var query = new GetCurrentDetailedUserQuery(SharedTestUtilities.GetString(length));

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
    {
        // Arrange
        var query = new GetCurrentDetailedUserQuery(UserTestUtilities.InvalidId);

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
        var query = new GetCurrentDetailedUserQuery(existingUser.Id);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == existingUser.Id &&
                                          m.UserName == existingUser.UserName &&
                                          m.FirstName == existingUser.FirstName &&
                                          m.LastName == existingUser.LastName &&
                                          m.ProfileImage == existingUser.ProfileImage &&
                                          m.Email == existingUser.Email);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenQueryIsValidAndCaseDoesNotMatch()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentDetailedUserQuery(SharedTestUtilities.GetNonCaseMatchingString(existingUser.Id));

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == existingUser.Id &&
                                          m.UserName == existingUser.UserName &&
                                          m.FirstName == existingUser.FirstName &&
                                          m.LastName == existingUser.LastName &&
                                          m.ProfileImage == existingUser.ProfileImage &&
                                          m.Email == existingUser.Email);
    }

    [Fact]
    public async Task SendAsync_ShouldSaveUserDetailedViewModelCollectionToCacheService_WhenQueryIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetCurrentDetailedUserQuery(existingUser.Id);

        // Act
        await InstaConnectSender.SendAsync(query, CancellationToken);

        var result = await CacheHandler.GetAsync<UserDetailedQueryViewModel>(query.Key, CancellationToken);

        // Assert
        result
            .Should()
            .Match<UserDetailedQueryViewModel>(m => m.Id == existingUser.Id &&
                                          m.UserName == existingUser.UserName &&
                                          m.FirstName == existingUser.FirstName &&
                                          m.LastName == existingUser.LastName &&
                                          m.ProfileImage == existingUser.ProfileImage &&
                                          m.Email == existingUser.Email);
    }
}
