using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using Bogus;
using FluentAssertions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Data.Features.Follows.Models.Entities;
using InstaConnect.Follows.Web.Features.Follows.Models.Binding;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Web.FunctionalTests.Utilities;

namespace InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Controllers.v1;

public class AddFollowFunctionalTests : BaseFollowFunctionalTest
{
    public AddFollowFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowBindingModel(existingFollowingId);

        // Act
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenFollowingIdIsNull()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowBindingModel(null!);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.FOLLOWING_ID_MAX_LENGTH + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowBindingModel(Faker.Random.AlphaNumeric(length));

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }


    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowBindingModel(existingFollowingId);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.CURRENT_USER_ID_MAX_LENGTH + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowBindingModel(existingFollowingId);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = Faker.Random.AlphaNumeric(length);

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowBindingModel(existingFollowingId);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = FollowTestUtilities.InvalidUserId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenFollowingIdIsInvalid()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowBindingModel(FollowTestUtilities.InvalidUserId);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenFollowAlreadyExists()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new AddFollowBindingModel(existingFollowingId);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowBindingModel(existingFollowingId);


        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddFollow_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowBindingModel(existingFollowingId);

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        HttpClient.SetFakeJwtBearerToken(ValidJwtConfig);
        var response = await HttpClient.PostAsJsonAsync(ApiRoute, request, CancellationToken);

        var followCommandResponse = await response
            .Content
            .ReadFromJsonAsync<FollowCommandResponse>();

        var message = await FollowWriteRepository.GetByIdAsync(followCommandResponse!.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Follow>(m => m.Id == followCommandResponse.Id &&
                                 m.FollowerId == existingFollowerId &&
                                 m.FollowingId == existingFollowingId);
    }
}
