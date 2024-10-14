using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Web.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Controllers.v1;

public class GetFollowByIdFunctionalTests : BaseFollowFunctionalTest
{
    public GetFollowByIdFunctionalTests(FunctionalTestWebAppFactory functionalTestWebAppFactory) : base(functionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(FollowBusinessConfigurations.ID_MIN_LENGTH - 1)]
    [InlineData(FollowBusinessConfigurations.ID_MAX_LENGTH + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = SharedTestUtilities.GetString(length)
        };

        // Act
        var response = await FollowsClient.GetByIdStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = FollowTestUtilities.InvalidId
        };

        // Act
        var response = await FollowsClient.GetByIdStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = existingFollowId
        };

        // Act
        var response = await FollowsClient.GetByIdStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = SharedTestUtilities.GetNonCaseMatchingString(existingFollowId)
        };

        // Act
        var response = await FollowsClient.GetByIdStatusCodeAsync(request);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnFollowQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = existingFollowId
        };

        // Act
        var response = await FollowsClient.GetByIdAsync(request);

        // Assert
        response
            .Should()
            .Match<FollowQueryResponse>(m => m.Id == existingFollowId &&
                                 m.FollowerId == existingFollowerId &&
                                 m.FollowerName == FollowTestUtilities.ValidUserName &&
                                 m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                 m.FollowingId == existingFollowingId &&
                                 m.FollowingName == FollowTestUtilities.ValidUserName &&
                                 m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnFollowQueryResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = SharedTestUtilities.GetNonCaseMatchingString(existingFollowId)
        };

        // Act
        var response = await FollowsClient.GetByIdAsync(request);

        // Assert
        response
            .Should()
            .Match<FollowQueryResponse>(m => m.Id == existingFollowId &&
                                 m.FollowerId == existingFollowerId &&
                                 m.FollowerName == FollowTestUtilities.ValidUserName &&
                                 m.FollowerProfileImage == FollowTestUtilities.ValidUserProfileImage &&
                                 m.FollowingId == existingFollowingId &&
                                 m.FollowingName == FollowTestUtilities.ValidUserName &&
                                 m.FollowingProfileImage == FollowTestUtilities.ValidUserProfileImage);
    }
}
