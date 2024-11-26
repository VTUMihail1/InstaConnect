using FluentAssertions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAllUsers;
using InstaConnect.Identity.Application.IntegrationTests.Features.Users.Utilities;
using InstaConnect.Identity.Application.IntegrationTests.Utilities;
using InstaConnect.Identity.Common.Features.Users.Utilities;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Queries;

public class GetAllUsersQueryHandlerIntegrationTests : BaseUserIntegrationTest
{
    public GetAllUsersQueryHandlerIntegrationTests(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Theory]
    [InlineData(UserBusinessConfigurations.USER_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.USER_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(UserBusinessConfigurations.FIRST_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.FIRST_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(UserBusinessConfigurations.LAST_NAME_MIN_LENGTH - 1)]
    [InlineData(UserBusinessConfigurations.LAST_NAME_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            null!,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenMessageDoesNotContaintSortPropertyName()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.InvalidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MIN_LENGTH - 1)]
    [InlineData(SharedBusinessConfigurations.SORT_ORDER_MAX_LENGTH + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_MAX_VALUE + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            value,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Theory]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MIN_VALUE - 1)]
    [InlineData(SharedBusinessConfigurations.PAGE_SIZE_MAX_VALUE + 1)]
    public async Task SendAsync_ShouldThrowBadRequestException_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action.Should().ThrowAsync<BadRequestException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenUserNameIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            null!,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenUserNameIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            string.Empty,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenUserNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidName),
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenUserNameIsNotFull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidName),
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenFirstNameIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            null!,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenFirstNameIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            string.Empty,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenFirstNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidFirstName),
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenFirstNameIsNotFull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidFirstName),
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenLastNameIsNull()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            null!,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenLastNameIsEmpty()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            string.Empty,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenLastNameCaseDoesNotMatch()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            SharedTestUtilities.GetNonCaseMatchingString(UserTestUtilities.ValidLastName),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenLastNameIsNotFulll()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            SharedTestUtilities.GetHalfStartString(UserTestUtilities.ValidLastName),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenQueryIsValid()
    {
        // Arrange
        var existingUserId = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            UserTestUtilities.ValidName,
            UserTestUtilities.ValidFirstName,
            UserTestUtilities.ValidLastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUserId &&
                                                                    m.UserName == UserTestUtilities.ValidName &&
                                                                    m.FirstName == UserTestUtilities.ValidFirstName &&
                                                                    m.LastName == UserTestUtilities.ValidLastName &&
                                                                    m.ProfileImage == UserTestUtilities.ValidProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
