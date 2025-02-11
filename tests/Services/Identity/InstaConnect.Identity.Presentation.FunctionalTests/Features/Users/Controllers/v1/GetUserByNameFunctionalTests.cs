using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Controllers.v1;

public class GetUserByNameFunctionalTests : BaseUserFunctionalTest
{
    public GetUserByNameFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task GetByNameAsync_ShouldReturnBadRequestResponse_WhenNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
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
        var existingUser = await CreateUserAsync(CancellationToken);
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
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage);
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
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
