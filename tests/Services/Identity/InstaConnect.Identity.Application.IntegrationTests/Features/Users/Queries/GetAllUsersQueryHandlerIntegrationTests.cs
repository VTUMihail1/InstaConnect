using InstaConnect.Common.Tests.Utilities;
using InstaConnect.Identity.Application.Features.Users.Queries.GetAll;
using InstaConnect.Identity.Common.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.IntegrationTests.Features.Users.Queries;

public class GetAllUsersQueryHandlerIntegrationTests : BaseUserIntegrationTest
{
    public GetAllUsersQueryHandlerIntegrationTests(IdentityWebApplicationFactory identityWebApplicationFactory) : base(identityWebApplicationFactory)
    {
    }

    [Theory]
    [InlineData(UserConfigurations.NameMinLength - 1)]
    [InlineData(UserConfigurations.NameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenUserNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            SharedTestUtilities.GetString(length),
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(UserConfigurations.FirstNameMinLength - 1)]
    [InlineData(UserConfigurations.FirstNameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenFirstNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            SharedTestUtilities.GetString(length),
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(UserConfigurations.LastNameMinLength - 1)]
    [InlineData(UserConfigurations.LastNameMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenLastNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortPropertyNameIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            null,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldThrowValidationException_WhenMessageDoesNotContaintSortPropertyName()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.InvalidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(default(int))]
    [InlineData(SharedConfigurations.SortOrderMinLength - 1)]
    [InlineData(SharedConfigurations.SortOrderMaxLength + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortPropertyNameLengthIsInvalid(int length)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            SharedTestUtilities.GetString(length),
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(SharedConfigurations.PageMinValue - 1)]
    [InlineData(SharedConfigurations.PageMaxValue + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageValueIsInvalid(int value)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            value,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Theory]
    [InlineData(SharedConfigurations.PageSizeMinValue - 1)]
    [InlineData(SharedConfigurations.PageSizeMaxValue + 1)]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageSizeValueIsInvalid(int value)
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            value);

        // Act
        var action = async () => await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        await action
            .Should()
            .ThrowAsync<AppValidationException>();
    }

    [Fact]
    public async Task SendAsync_ShouldReturnUserViewModelCollection_WhenUserNameIsNull()
    {
        // Arrange
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            null,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            string.Empty,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            SharedTestUtilities.GetNonCaseMatchingString(existingUser.UserName),
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            SharedTestUtilities.GetHalfStartString(existingUser.UserName),
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            null,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            string.Empty,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            SharedTestUtilities.GetNonCaseMatchingString(existingUser.FirstName),
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            SharedTestUtilities.GetHalfStartString(existingUser.FirstName),
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            null,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
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
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            SharedTestUtilities.GetNonCaseMatchingString(existingUser.LastName),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            SharedTestUtilities.GetHalfStartString(existingUser.LastName),
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
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
        var existingUser = await CreateUserAsync(CancellationToken);
        var query = new GetAllUsersQuery(
            existingUser.UserName,
            existingUser.FirstName,
            existingUser.LastName,
            UserTestUtilities.ValidSortOrderProperty,
            UserTestUtilities.ValidSortPropertyName,
            UserTestUtilities.ValidPageValue,
            UserTestUtilities.ValidPageSizeValue);

        // Act
        var response = await InstaConnectSender.SendAsync(query, CancellationToken);

        // Assert
        response
            .Should()
            .Match<UserPaginationQueryViewModel>(mc => mc.Items.All(m => m.Id == existingUser.Id &&
                                                                    m.UserName == existingUser.UserName &&
                                                                    m.FirstName == existingUser.FirstName &&
                                                                    m.LastName == existingUser.LastName &&
                                                                    m.ProfileImage == existingUser.ProfileImage) &&
                                                           mc.Page == UserTestUtilities.ValidPageValue &&
                                                           mc.PageSize == UserTestUtilities.ValidPageSizeValue &&
                                                           mc.TotalCount == UserTestUtilities.ValidTotalCountValue &&
                                                           !mc.HasPreviousPage &&
                                                           !mc.HasNextPage);
    }
}
