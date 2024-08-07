﻿using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using InstaConnect.Follows.Business.Features.Follows.Utilities;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Utilities;
using InstaConnect.Follows.Web.FunctionalTests.Utilities;

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

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(Faker.Random.AlphaNumeric(length)), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhenIdIsInvalid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(InvalidId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingFollowId), CancellationToken);

        // Assert
        response.Should().Match<HttpResponseMessage>(m => m.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnFollowQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(existingFollowId), CancellationToken);

        var followQueryResponse = await response
            .Content
            .ReadFromJsonAsync<FollowQueryResponse>();

        // Assert
        followQueryResponse
            .Should()
            .Match<FollowQueryResponse>(m => m.Id == existingFollowId &&
                                 m.FollowerId == existingFollowerId &&
                                 m.FollowerName == ValidUserName &&
                                 m.FollowerProfileImage == ValidUserProfileImage &&
                                 m.FollowingId == existingFollowingId &&
                                 m.FollowingName == ValidUserName &&
                                 m.FollowingProfileImage == ValidUserProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnFollowQueryResponse_WhenRequestIsValidAndIdCaseDoesNotMatch()
    {
        // Arrange
        var existingFollowerId = await CreateUserAsync(CancellationToken);
        var existingFollowingId = await CreateUserAsync(CancellationToken);
        var existingFollowId = await CreateFollowAsync(existingFollowerId, existingFollowingId, CancellationToken);

        // Act
        var response = await HttpClient.GetAsync(GetIdRoute(GetNonCaseMatchingString(existingFollowId)), CancellationToken);

        var followQueryResponse = await response
            .Content
            .ReadFromJsonAsync<FollowQueryResponse>();

        // Assert
        followQueryResponse
            .Should()
            .Match<FollowQueryResponse>(m => m.Id == existingFollowId &&
                                 m.FollowerId == existingFollowerId &&
                                 m.FollowerName == ValidUserName &&
                                 m.FollowerProfileImage == ValidUserProfileImage &&
                                 m.FollowingId == existingFollowingId &&
                                 m.FollowingName == ValidUserName &&
                                 m.FollowingProfileImage == ValidUserProfileImage);
    }
}