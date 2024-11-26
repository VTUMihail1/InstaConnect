using System.Net;
using System.Security.Claims;
using FluentAssertions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Binding;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Controllers.v1;

public class AddFollowFunctionalTests : BaseFollowFunctionalTest
{
    public AddFollowFunctionalTests(FollowsFunctionalTestWebAppFactory followsFunctionalTestWebAppFactory) : base(followsFunctionalTestWebAppFactory)
    {

    }

    [Fact]
    public async Task AddAsync_ShouldReturnUnauthorizedResponse_WhenUserIsUnauthorized()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowingId)
        };

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenFollowingIdIsNull()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            AddFollowBindingModel = new AddFollowBindingModel(null!)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(UserConfigurations.IdMinLength - 1)]
    [InlineData(UserConfigurations.IdMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenFollowingIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            AddFollowBindingModel = new AddFollowBindingModel(SharedTestUtilities.GetString(length))
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdIsNull()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowingId)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = null!;

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenCurrentUserIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowingId)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = SharedTestUtilities.GetString(length);

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenCurrentUserIdIsInvalid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowingId)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = FollowTestUtilities.InvalidUserId;

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnNotFoundResponse_WhenFollowingIdIsInvalid()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            AddFollowBindingModel = new AddFollowBindingModel(FollowTestUtilities.InvalidUserId)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnBadRequestResponse_WhenFollowAlreadyExists()
    {
        // Arrange
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);
        var request = new AddFollowRequest
        {
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowingId)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowingId)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        var statusCode = await FollowsClient.AddStatusCodeAsync(request, ValidJwtConfig);

        // Assert
        statusCode
            .Should()
            .Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddAsync_ShouldAddFollow_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var request = new AddFollowRequest
        {
            AddFollowBindingModel = new AddFollowBindingModel(existingFollowingId)
        };

        ValidJwtConfig[ClaimTypes.NameIdentifier] = existingFollowerId;

        // Act
        var response = await FollowsClient.AddAsync(request, ValidJwtConfig);
        var message = await FollowWriteRepository.GetByIdAsync(response!.Id, CancellationToken);

        // Assert
        message
            .Should()
            .Match<Follow>(m => m.Id == response.Id &&
                                 m.FollowerId == existingFollowerId &&
                                 m.FollowingId == existingFollowingId);
    }
}
