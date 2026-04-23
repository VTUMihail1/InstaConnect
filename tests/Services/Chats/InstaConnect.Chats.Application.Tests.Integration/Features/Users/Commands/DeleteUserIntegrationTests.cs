using InstaConnect.Chats.Tests.Features.Common.Utilities;

namespace InstaConnect.Chats.Application.Tests.Integration.Features.Users.Commands;

public class DeleteUserIntegrationTests : BaseUserApplicationCommandIntegrationTest
{
    private readonly DeleteUserCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeleteUserCommandRequestBuilder _requestBuilder;
    private readonly DeleteUserCommandRequest _request;

    public DeleteUserIntegrationTests(ChatsWebApplicationFactory webApplicationFactory)
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
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForIdAsync(messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldThrowUserNotFoundException_WhenRequestIsInvalid()
    {
        // Arrange
        await ServiceScope.DeleteUserAsync(User, CancellationToken);

        // Assert
        await Sender.ShouldThrowUserNotFoundExceptionAsync(_request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldDeleteUser_WhenRequestIsValid()
    {
        // Act
        await Sender.SendAsync(_request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }

    [Theory]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldDeleteUser_WhenIdIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithId(transformer).Build();

        // Act
        await Sender.SendAsync(request, CancellationToken);
        var user = await ServiceScope.GetUserByIdAsync(User.Id, CancellationToken);

        // Assert
        user.ShouldBeNull();
    }
}
