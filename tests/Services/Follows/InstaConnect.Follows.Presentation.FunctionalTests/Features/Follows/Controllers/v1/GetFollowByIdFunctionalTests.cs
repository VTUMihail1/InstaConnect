using System.Net;
using FluentAssertions;
using InstaConnect.Follows.Common.Features.Follows.Utilities;
using InstaConnect.Follows.Common.Features.Users.Utilities;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Presentation.FunctionalTests.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Controllers.v1;

public class GetFollowByIdFunctionalTests : BaseFollowFunctionalTest
{
    public GetFollowByIdFunctionalTests(FollowsFunctionalTestWebAppFactory followsFunctionalTestWebAppFactory) : base(followsFunctionalTestWebAppFactory)
    {

    }

    [Theory]
    [InlineData(FollowConfigurations.IdMinLength - 1)]
    [InlineData(FollowConfigurations.IdMaxLength + 1)]
    public async Task GetByIdAsync_ShouldReturnBadRequestResponse_WhenIdLengthIsInvalid(int length)
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = SharedTestUtilities.GetString(length)
        };


        // Act
        var response = await FollowsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = FollowTestUtilities.InvalidId
        };


        // Act
        var response = await FollowsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = existingFollow.Id
        };


        // Act
        var response = await FollowsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = SharedTestUtilities.GetNonCaseMatchingString(existingFollow.Id)
        };


        // Act
        var response = await FollowsClient.GetByIdStatusCodeAsync(request, CancellationToken);

        // Assert
        response.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnFollowQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = existingFollow.Id
        };


        // Act
        var response = await FollowsClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryResponse>(m => m.Id == existingFollow.Id &&
                                 m.FollowerId == existingFollow.FollowerId &&
                                 m.FollowerName == UserTestUtilities.ValidName &&
                                 m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                 m.FollowingId == existingFollow.FollowingId &&
                                 m.FollowingName == UserTestUtilities.ValidName &&
                                 m.FollowingProfileImage == UserTestUtilities.ValidProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnFollowQueryResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollow = await CreateFollowAsync(CancellationToken);
        var request = new GetFollowByIdRequest
        {
            Id = SharedTestUtilities.GetNonCaseMatchingString(existingFollow.Id)
        };


        // Act
        var response = await FollowsClient.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Should()
            .Match<FollowQueryResponse>(m => m.Id == existingFollow.Id &&
                                 m.FollowerId == existingFollow.FollowerId &&
                                 m.FollowerName == UserTestUtilities.ValidName &&
                                 m.FollowerProfileImage == UserTestUtilities.ValidProfileImage &&
                                 m.FollowingId == existingFollow.FollowingId &&
                                 m.FollowingName == UserTestUtilities.ValidName &&
                                 m.FollowingProfileImage == UserTestUtilities.ValidProfileImage);
    }
}
