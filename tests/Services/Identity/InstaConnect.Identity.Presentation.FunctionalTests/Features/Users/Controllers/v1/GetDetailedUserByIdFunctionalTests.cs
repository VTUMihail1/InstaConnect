namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class GetDetailedUserByIdFunctionalTests : BaseUserFunctionalTest
{
    public GetDetailedUserByIdFunctionalTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {

    }

    [Fact]
    public async Task GetDetailedById_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetDetailedUserByIdRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.GetDetailedByIdStatusCodeUnathorizedAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task GetDetailedById_ShouldReturnForbiddenResponse_WhenUserIsNotAdmin()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetDetailedUserByIdRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.GetDetailedByIdStatusCodeNonAdminAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Theory]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task GetDetailedById_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var request = new GetDetailedUserByIdRequest(
            SharedTestUtilities.GetString(length)
        );

        // Act
        var response = await UsersClient.GetDetailedByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetDetailedById_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var request = new GetDetailedUserByIdRequest(
            UserTestUtilities.InvalidId
        );

        // Act
        var response = await UsersClient.GetDetailedByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetDetailedById_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetDetailedUserByIdRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.GetDetailedByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetDetailedById_ShouldReturnUserViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetDetailedUserByIdRequest(
            existingUser.Id
        );

        // Act
        var response = await UsersClient.GetDetailedByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserDetailedQueryResponse>(m => m.Id == existingUser.Id &&
                                                                    m.Email == existingUser.Email &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage);
    }

    [Fact]
    public async Task GetDetailedById_ShouldReturnUserViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var request = new GetDetailedUserByIdRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingUser.Id)
        );

        // Act
        var response = await UsersClient.GetDetailedByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserDetailedQueryResponse>(m => m.Id == existingUser.Id &&
                                                                    m.Email == existingUser.Email &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage);
    }
}
