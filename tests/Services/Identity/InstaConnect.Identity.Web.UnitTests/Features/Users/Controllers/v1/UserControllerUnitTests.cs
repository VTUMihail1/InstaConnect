using System.Net;
using FluentAssertions;
using InstaConnect.Identity.Business.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUser;
using InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUserDetailed;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserById;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserByName;
using InstaConnect.Identity.Business.Features.Users.Queries.GetUserDetailedById;
using InstaConnect.Identity.Web.Features.Users.Controllers.v1;
using InstaConnect.Identity.Web.Features.Users.Models.Requests;
using InstaConnect.Identity.Web.Features.Users.Models.Responses;
using InstaConnect.Identity.Web.UnitTests.Features.Users.Utilities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace InstaConnect.Identity.Web.UnitTests.Features.Users.Controllers.v1;
public class UserControllerUnitTests : BaseUserUnitTest
{
    private readonly UserController _userController;

    public UserControllerUnitTests()
    {
        _userController = new(
            InstaConnectMapper,
            InstaConnectSender,
            CurrentUserContext);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllUsersRequest()
        {
            FirstName = ValidFirstName,
            LastName = ValidLastName,
            UserName = ValidName,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _userController.GetAllAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnUserPaginationQueryResponse_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllUsersRequest()
        {
            FirstName = ValidFirstName,
            LastName = ValidLastName,
            UserName = ValidName,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

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
                                                                 m.Id == ValidId &&
                                                                 m.FirstName == ValidFirstName &&
                                                                 m.LastName == ValidLastName &&
                                                                 m.UserName == ValidName &&
                                                                 m.ProfileImage == ValidProfileImage) &&
                                                              mc.Page == ValidPageValue &&
                                                              mc.PageSize == ValidPageSizeValue &&
                                                              mc.TotalCount == ValidTotalCountValue &&
                                                              !mc.HasNextPage &&
                                                              !mc.HasPreviousPage);
    }

    [Fact]
    public async Task GetAllAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetAllUsersRequest()
        {
            FirstName = ValidFirstName,
            LastName = ValidLastName,
            UserName = ValidName,
            SortOrder = ValidSortOrderProperty,
            SortPropertyName = ValidSortPropertyName,
            Page = ValidPageValue,
            PageSize = ValidPageSizeValue,
        };

        // Act
        var response = await _userController.GetAllAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetAllUsersQuery>(m =>
                  m.FirstName == ValidFirstName &&
                  m.LastName == ValidLastName &&
                  m.UserName == ValidName &&
                  m.SortOrder == ValidSortOrderProperty &&
                  m.SortPropertyName == ValidSortPropertyName &&
                  m.Page == ValidPageValue &&
                  m.PageSize == ValidPageSizeValue), CancellationToken);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserByIdRequest()
        {
            Id = ValidId
        };

        // Act
        var response = await _userController.GetByIdAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserByIdRequest()
        {
            Id = ValidId
        };

        // Act
        var response = await _userController.GetByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserQueryResponse>(m => m.Id == ValidId &&
                                           m.FirstName == ValidFirstName &&
                                           m.LastName == ValidLastName &&
                                           m.UserName == ValidName &&
                                           m.ProfileImage == ValidProfileImage);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserByIdRequest()
        {
            Id = ValidId
        };

        // Act
        await _userController.GetByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetUserByIdQuery>(m => m.Id == ValidId), CancellationToken);
    }

    [Fact]
    public async Task GetDetailedByIdAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserDetailedByIdRequest()
        {
            Id = ValidId
        };

        // Act
        var response = await _userController.GetDetailedByIdAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetDetailedByIdAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserDetailedByIdRequest()
        {
            Id = ValidId
        };

        // Act
        var response = await _userController.GetDetailedByIdAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserDetailedQueryResponse>(m => m.Id == ValidId &&
                                           m.FirstName == ValidFirstName &&
                                           m.LastName == ValidLastName &&
                                           m.UserName == ValidName &&
                                           m.Email == ValidEmail &&
                                           m.ProfileImage == ValidProfileImage);
    }

    [Fact]
    public async Task GetDetailedByIdAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserDetailedByIdRequest()
        {
            Id = ValidId
        };

        // Act
        await _userController.GetDetailedByIdAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetUserDetailedByIdQuery>(m => m.Id == ValidId), CancellationToken);
    }

    [Fact]
    public async Task GetByNameAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserByNameRequest()
        {
            UserName = ValidName
        };

        // Act
        var response = await _userController.GetByNameAsync(request, CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetByNameAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserByNameRequest()
        {
            UserName = ValidName
        };

        // Act
        var response = await _userController.GetByNameAsync(request, CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserQueryResponse>(m => m.Id == ValidId &&
                                           m.FirstName == ValidFirstName &&
                                           m.LastName == ValidLastName &&
                                           m.UserName == ValidName &&
                                           m.ProfileImage == ValidProfileImage);
    }

    [Fact]
    public async Task GetByNameAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Arrange
        var request = new GetUserByNameRequest()
        {
            UserName = ValidName
        };

        // Act
        await _userController.GetByNameAsync(request, CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Is<GetUserByNameQuery>(m => m.UserName == ValidName), CancellationToken);
    }

    [Fact]
    public async Task GetCurrentAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _userController.GetCurrentAsync(CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetCurrentAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Act
        var response = await _userController.GetCurrentAsync(CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserQueryResponse>(m => m.Id == ValidId &&
                                           m.FirstName == ValidFirstName &&
                                           m.LastName == ValidLastName &&
                                           m.UserName == ValidName &&
                                           m.ProfileImage == ValidProfileImage);
    }

    [Fact]
    public async Task GetCurrentAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Act
        await _userController.GetCurrentAsync(CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Any<GetCurrentUserQuery>(), CancellationToken);
    }

    [Fact]
    public async Task GetCurrentAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Act
        await _userController.GetCurrentAsync(CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }

    [Fact]
    public async Task GetCurrentDetailedAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await _userController.GetCurrentDetailedAsync(CancellationToken);

        // Assert
        response
            .Result
            .Should()
            .Match<OkObjectResult>(m => m.StatusCode == Convert.ToInt32(HttpStatusCode.OK));
    }

    [Fact]
    public async Task GetCurrentDetailedAsync_ShouldReturnMessageViewModel_WhenRequestIsValid()
    {
        // Act
        var response = await _userController.GetCurrentDetailedAsync(CancellationToken);

        // Assert
        response.Result
            .Should()
            .BeOfType<OkObjectResult>()
            .Which
            .Value
            .Should()
            .Match<UserDetailedQueryResponse>(m => m.Id == ValidId &&
                                           m.FirstName == ValidFirstName &&
                                           m.LastName == ValidLastName &&
                                           m.UserName == ValidName &&
                                           m.Email == ValidEmail &&
                                           m.ProfileImage == ValidProfileImage);
    }

    [Fact]
    public async Task GetCurrentDetailedAsync_ShouldCallTheSender_WhenRequestIsValid()
    {
        // Act
        await _userController.GetCurrentDetailedAsync(CancellationToken);

        // Assert
        await InstaConnectSender
              .Received(1)
              .SendAsync(Arg.Any<GetCurrentUserDetailedQuery>(), CancellationToken);
    }

    [Fact]
    public async Task GetCurrentDetailedAsync_ShouldCallTheCurrentUserContext_WhenRequestIsValid()
    {
        // Act
        await _userController.GetCurrentDetailedAsync(CancellationToken);

        // Assert
        CurrentUserContext
            .Received(1)
            .GetCurrentUser();
    }
}
