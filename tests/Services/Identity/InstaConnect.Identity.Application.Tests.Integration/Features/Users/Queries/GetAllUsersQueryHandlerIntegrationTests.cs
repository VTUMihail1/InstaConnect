using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Application.Tests.Integration.Features.Users.Queries;

public class GetAllUsersQueryHandlerIntegrationTests : BaseUserApplicationQueryIntegrationTest
{
    private readonly GetAllUsersQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllUsersQueryRequestBuilder _requestBuilder;
    private readonly GetAllUsersQueryRequest _request;

    public GetAllUsersQueryHandlerIntegrationTests(IdentityWebApplicationFactory webApplicationFactory)
        : base(webApplicationFactory)
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(User);
        _request = _requestBuilder.Build();
    }

    protected override async Task OnInitializeAsync()
    {
        await ServiceScope.AddUserRangeAsync(Users, CancellationToken);
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForNameAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserFirstNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenFirstNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithFirstName(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForFirstNameAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserLastNameTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenLastNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithLastName(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForLastNameAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserIdTooLongWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenCurrentIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentId(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForCurrentIdAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UsersSortOrderEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForSortOrderAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UsersSortTermEmptyWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenSortTermIsInvalid(
        IEnumTransformer<UsersSortTerm> transformer, IEnumMessageTransformer<UsersSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForSortTermAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserPageTooSmallWithMessageData]
    [UserPageTooLargeWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForPageAsync(
            messageTransformer, request, CancellationToken);
    }

    [Theory]
    [UserPageSizeTooSmallWithMessageData]
    [UserPageSizeTooLargeWithMessageData]
    public async Task SendAsync_ShouldThrowValidationException_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Assert
        await Sender.ShouldThrowInvalidValidationExceptionForPageSizeAsync(
            messageTransformer, request, CancellationToken);
    }

    [Fact]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestIsValid()
    {
        // Act
        var response = await Sender.SendAsync(_request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Users, _request);
    }

    [Theory]
    [UserNameNullData]
    [UserNameEmptyData]
    [UserNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithName(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Users, request);
    }

    [Theory]
    [UserFirstNameNullData]
    [UserFirstNameEmptyData]
    [UserFirstNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndFirstNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithFirstName(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Users, request);
    }

    [Theory]
    [UserLastNameNullData]
    [UserLastNameEmptyData]
    [UserLastNameDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndLastNameAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithLastName(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Users, request);
    }

    [Theory]
    [UserIdNullData]
    [UserIdEmptyData]
    [UserIdDifferentCaseData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndCurrentIdAreValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentId(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Users, request);
    }

    [Theory]
    [UsersSortOrderWithAscendingTermData]
    [UsersSortOrderWithDescendingTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortOrderAreValid(
        IEnumTransformer<CommonSortOrder> transformer, ISortEnumTermTransformer<User> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Users, request, termTransformer);
    }

    [Theory]
    [UsersSortTermWithCreatedAtTermData]
    [UsersSortTermWithNameTermData]
    [UsersSortTermWithFirstNameTermData]
    [UsersSortTermWithLastNameTermData]
    public async Task SendAsync_ShouldReturnResponse_WhenRequestAndSortTermAreValid(
        IEnumTransformer<UsersSortTerm> transformer, ISortEnumTermTransformer<User> termTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var response = await Sender.SendAsync(request, CancellationToken);

        // Assert
        response.ShouldSatisfy(Users, request, termTransformer);
    }
}
