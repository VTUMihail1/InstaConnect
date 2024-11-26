using System.Net;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Controllers.v1;

public class DeleteFollowFunctionalTests : BaseFollowFunctionalTest
{
    public DeleteFollowFunctionalTests(FollowsFunctionalTestWebAppFactory followsFunctionalTestWebAppFactory) : base(followsFunctionalTestWebAppFactory)
    {
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new DeleteFollowRequest
        {
            Id = existingFollowId
        };

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request);

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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new DeleteFollowRequest
        {
            Id = SharedTestUtilities.GetString(length)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new DeleteFollowRequest
        {
            Id = existingFollowId
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, ValidJwtConfig);

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
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new DeleteFollowRequest
        {
            Id = existingFollowId
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetString(length);

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new DeleteFollowRequest
        {
            Id = FollowTestUtilities.InvalidId
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnForbiddenResponse_WhenCurrentUserIdDoesNotOwnTheFollow()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var otherFollowerId = await CreateUserAsync(CancellationToken);
        var otherFollowingId = await CreateUserAsync(CancellationToken);
        var otherFollowId = await CreateFollowAsync(otherFollowerId, otherFollowingId, CancellationToken);

        var request = new DeleteFollowRequest
        {
            Id = otherFollowId
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.Forbidden);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new DeleteFollowRequest
        {
            Id = existingFollowId
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnNoContentResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new DeleteFollowRequest
        {
            Id = SharedTestUtilities.GetNonCaseMatchingString(existingFollowId)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        var statusCode = await FollowsClient.DeleteStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteFollow_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new DeleteFollowRequest
        {
            Id = existingFollowId
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        await FollowsClient.DeleteAsync(request, ValidJwtConfig);
        var follow = await FollowWriteRepository.GetByIdAsync(existingFollowId, CancellationToken);

        // Assert
        follow
            .Should()
            .BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteFollow_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        var request = new DeleteFollowRequest
        {
            Id = SharedTestUtilities.GetNonCaseMatchingString(existingFollowId)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        await FollowsClient.DeleteAsync(request, ValidJwtConfig);
        var follow = await FollowWriteRepository.GetByIdAsync(existingFollowId, CancellationToken);

        // Assert
        follow
            .Should()
            .BeNull();
    }
}
