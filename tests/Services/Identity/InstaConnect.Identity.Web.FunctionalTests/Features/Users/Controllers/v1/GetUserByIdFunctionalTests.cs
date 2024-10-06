using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Identity.Web.Features.Users.Models.Responses;
using InstaConnect.Identity.Web.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Identity.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Web.FunctionalTests.Features.Users.Controllers.v1;

public class GetUserByIdFunctionalTests : BaseUserFunctionalTest
{
    public GetUserByIdFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(UserBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(SharedTestUtilities.GetString(length)), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(UserTestUtilities.InvalidId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingUserId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnUserViewResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingUserId), CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserQueryResponse>();

        // Assert
        userViewResponse
            .Should()
            .Match<UserQueryResponse>(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnUserViewResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(SharedTestUtilities.GetNonCaseMatchingString(existingUserId)), CancellationToken);

        var userViewResponse = await response
            .Content
            .ReadFromJsonAsync<UserQueryResponse>();

        // Assert
        userViewResponse
            .Should()
            .Match<UserQueryResponse>(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
