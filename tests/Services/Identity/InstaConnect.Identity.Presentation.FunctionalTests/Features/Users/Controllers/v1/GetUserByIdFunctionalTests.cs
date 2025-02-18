namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class GetUserByIdFunctionalTests : BaseUserFunctionalTest
{
    public GetUserByIdFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var request = new GetUserByIdRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await UsersClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var request = new GetUserByIdRequest(
            UserTestUtilities.InvalidId
        );

        // Act
        var response = await UsersClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetUserByIdRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnUserViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetUserByIdRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.GetByIdAsync(request, CancellationToken);

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
    public async Task GetByIdAsync_ShouldReturnUserViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetUserByIdRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingUser.Id)
        );

        // Act
        var response = await UsersClient.GetByIdAsync(request, CancellationToken);

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
