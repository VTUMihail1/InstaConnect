namespace InstaConnect.Posts.Application.Tests.Integration.Features.Users.Commands;

public class DeleteUserIntegrationTests : BaseUserApplicationIntegrationTest
{
    private readonly DeleteUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteUserCommandRequestBuilder _requestBuilder;
    private readonly DeleteUserCommandRequest _request;

    public DeleteUserIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserAsync(User, CancellationToken);
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenIdIsInvalid(
        IStringTransformer transformer, string errorMessage)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        var action = async () => await ApplicationSender.SendAsync(request, CancellationToken);

        // Assert
        await action.ShouldThrowInvalidValidationExceptionAsync(errorMessage);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Act
        var action = async () => await ApplicationSender.SendAsync(_request, CancellationToken);

        // Assert
        await action.ShouldThrowUserAlreadyExistsExceptionAsync(_request.Id);
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteUser_WhenRequestIsValid()
    {
        // Act
        await ApplicationSender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(_request.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeleteUser_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(_request.Id, transformer).Build();

        // Act
        await ApplicationSender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(request.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }
}
