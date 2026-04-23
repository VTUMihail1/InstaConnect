using InstaConnect.Identity.Tests.Features.Common.Utilities;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

namespace InstaConnect.Identity.Presentation.Tests.Functional.Features.EmailConfirmationTokens.Controllers.v1;

public class AddEmailConfirmationTokenFunctionalTests : BaseEmailConfirmationTokenPresentationCommandFunctionalTest
{
    private readonly AddEmailConfirmationTokenApiRequestBuilderFactory _requestBuilderFactory;
    private readonly AddEmailConfirmationTokenApiRequestBuilder _requestBuilder;
    private readonly AddEmailConfirmationTokenApiRequest _request;

    public AddEmailConfirmationTokenFunctionalTests(IdentityWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
        await ServiceScope.AddUserClaimAsync(UserClaim, CancellationToken);
    }

    [Theory]
    [UserNameTooShortData]
    [UserNameTooLongData]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenNameIsInvalid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await HttpClient.AddEmailConfirmationTokenStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Theory]
    [UserNameTooShortWithMessageData]
    [UserNameTooLongWithMessageData]
    public async Task AddAsync_ShouldHaveBadRequestProblemDetails_WhenNameIsInvalid(
        IStringTransformer transformer,
        IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await HttpClient.AddEmailConfirmationTokenProblemDetailsAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfyInvalidValidationForName(messageTransformer, request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveNotFoundStatusCode_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddEmailConfirmationTokenStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNotFound();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveUserNameNotFoundProblemDetails_WhenUserNotFound()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var response = await HttpClient.AddEmailConfirmationTokenProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNameNotFound(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveBadRequestStatusCode_WhenEmailIsConfirmed()
    {
        // Arrange
        var updatedUser = UserBuilder.WithConfirmedEmail().Build();
        await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

        // Act
        var response = await HttpClient.AddEmailConfirmationTokenStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeBadRequest();
    }

    [Fact]
    public async Task AddAsync_ShouldHaveUserNameEmailAlreadyConfirmedProblemDetails_WhenEmailIsConfirmed()
    {
        // Arrange
        var updatedUser = UserBuilder.WithConfirmedEmail().Build();
        await ServiceScope.UpdateUserAsync(updatedUser, CancellationToken);

        // Act
        var response = await HttpClient.AddEmailConfirmationTokenProblemDetailsAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfyUserNameEmailAlreadyConfirmed(_request);
    }

    [Fact]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenRequestIsValid()
    {
        // Act
        var response = await HttpClient.AddEmailConfirmationTokenStatusCodeAsync(_request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task AddAsync_ShouldHaveOkStatusCode_WhenNameIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await HttpClient.AddEmailConfirmationTokenStatusCodeAsync(request, CancellationToken);

        // Assert
        response.ShouldBeNoContent();
    }

    [Fact]
    public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenRequestIsValid()
    {
        // Act
        await HttpClient.AddEmailConfirmationTokenAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.EmailConfirmationTokens.ShouldNotBeEmpty();
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task AddAsync_ShouldAddEmailConfirmationToken_WhenNameIsValid(IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        await HttpClient.AddEmailConfirmationTokenAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.EmailConfirmationTokens.ShouldNotBeEmpty();
    }

    [Fact]
    public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestIsValid()
    {
        // Act
        await HttpClient.AddEmailConfirmationTokenAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedEmailConfirmationTokenAddedRangeAsync(user, CancellationToken);
    }

    [Theory]
    [UserNameDifferentCaseData]
    public async Task AddAsync_ShouldPublishEmailConfirmationTokenAddedEvent_WhenRequestAndNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        await HttpClient.AddEmailConfirmationTokenAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        await EventHarness.ShouldHavePublishedEmailConfirmationTokenAddedRangeAsync(user, CancellationToken);
    }
}
