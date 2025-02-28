using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Identity.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class GetUserByNameFunctionalTests : BaseUserFunctionalTest
{
    public GetUserByNameFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task GetByNameAsync_ShouldReturnBadRequestResponse_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var request = new GetUserByNameRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await UsersClient.GetByNameStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByNameAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var request = new GetUserByNameRequest(
            UserTestUtilities.ValidAddName
        );

        // Act
        var response = await UsersClient.GetByNameStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByNameAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetUserByNameRequest(
            existingUser.UserName
        );

        // Act
        var response = await UsersClient.GetByNameStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByNameAsync_ShouldReturnUserViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetUserByNameRequest(
            existingUser.UserName
        );

        // Act
        var response = await UsersClient.GetByNameAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryResponse>(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task GetByNameAsync_ShouldReturnUserViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetUserByNameRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingUser.UserName)
        );

        // Act
        var response = await UsersClient.GetByNameAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserQueryResponse>(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage);
    }
}
