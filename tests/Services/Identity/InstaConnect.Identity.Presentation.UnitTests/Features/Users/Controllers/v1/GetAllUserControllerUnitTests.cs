﻿using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

namespace InstaConnect.Identity.Presentation.UnitTests.Features.Users.Controllers.v1;

public class GetAllUserControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public GetAllUserControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _userController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue
        );

        // Act
        var response = await _userController.GetAllAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserPaginationQueryResponse>(mc => mc.Items.All(m =>
                                                                 m.Id == existingUser.Id &&
                                                                 m.FirstName == existingUser.FirstName &&
                                                                 m.LastName == existingUser.LastName &&
                                                                 m.UserName == existingUser.UserName &&
                                                                 m.ProfileImage == existingUser.ProfileImage) &&
                                                              mc.Page == UserTestUtilities.ValidPageValue &&
                                                              mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                              mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var existingUser = CreateUser();
        var request = new GetAllUsersRequest(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue
        );

        // Act
        await _userController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllUsersQuery>(m =>
                  m.FirstName == existingUser.FirstName &&
                  m.LastName == existingUser.LastName &&
                  m.UserName == existingUser.UserName &&
                  m.SortOrder == UserTestUtilities.ValidSortOrderProperty &&
                  m.SortPropertyName == UserTestUtilities.ValidSortPropertyName &&
                  m.Page == UserTestUtilities.ValidPageValue &&
                  m.PageSize == UserTestUtilities.ValidPageSizeValue), CancellationToken);
    }
}
