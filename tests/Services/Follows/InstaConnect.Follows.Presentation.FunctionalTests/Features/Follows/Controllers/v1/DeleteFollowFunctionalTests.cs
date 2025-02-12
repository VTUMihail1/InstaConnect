using System.Net;
using FluentAssertions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Controllers.v1;

public class DeleteFollowFunctionalTests : BaseFollowFunctionalTest
{
    public DeleteFollowFunctionalTests(FollowsWebApplicationFactory followsFunctionalTestWebAppFactory) : base(followsFunctionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var request = new DeleteFollowRequest(
            existingFollow.Id,
            existingFollow.FollowerId);

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeUnauthorizedAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Theory]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var request = new DeleteFollowRequest(
            SharedTestUtilities.GetString(length),
            existingFollow.FollowerId);

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var request = new DeleteFollowRequest(
            existingFollow.Id,
            null);

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var request = new DeleteFollowRequest(
            existingFollow.Id,
            SharedTestUtilities.GetString(length));

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingFollower = await CreateUserAsync(CancellationToken);

        var request = new DeleteFollowRequest(
            FollowTestUtilities.InvalidId,
            existingFollower.Id);

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnTheFollow()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var request = new DeleteFollowRequest(
            existingFollow.Id,
            existingUser.Id);

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var request = new DeleteFollowRequest(
            existingFollow.Id,
            existingFollow.FollowerId);

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var request = new DeleteFollowRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingFollow.Id),
            existingFollow.FollowerId);

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, CancellationToken);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteFollow_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var request = new DeleteFollowRequest(
            existingFollow.Id,
            existingFollow.FollowerId);

        // Act
        await FollowsClient.DeleteAsync(request, CancellationToken);
        var follow = await FollowWriteRepository.GetByIdAsync(existingFollow.Id, CancellationToken);

        // Assert
        follow
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteFollow_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);

        var request = new DeleteFollowRequest(
            SharedTestUtilities.GetNonCaseMatchingString(existingFollow.Id),
            existingFollow.FollowerId);

        // Act
        await FollowsClient.DeleteAsync(request, CancellationToken);
        var follow = await FollowWriteRepository.GetByIdAsync(existingFollow.Id, CancellationToken);

        // Assert
        follow
            .Should()
            .BeNull();
    }
}
