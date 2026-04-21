using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Application.Tests.Unit.Features.Chats.Queries.GetAll;

public class GetAllChatsQueryRequestValidatorUnitTests : BaseChatApplicationQueryUnitTest
{
    private readonly GetAllChatsQueryRequestBuilderFactory _requestBuilderFactory;
    private readonly GetAllChatsQueryRequestBuilder _requestBuilder;
    private readonly GetAllChatsQueryRequest _request;

    private readonly GetAllChatsQueryRequestValidator _requestValidator;

    public GetAllChatsQueryRequestValidatorUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(Chat);
        _request = _requestBuilder.Build();

        _requestValidator = new();
    }

    [Theory]
    [UserNameTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenParticipantTwoNameIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForParticipantTwoName(messageTransformer, request);
    }

    [Theory]
    [UserIdNullWithMessageData]
    [UserIdEmptyWithMessageData]
    [UserIdTooShortWithMessageData]
    [UserIdTooLongWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenCurrentUserIdIsInvalid(
        IStringTransformer transformer, IStringMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithCurrentUserId(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForCurrentUserId(messageTransformer, request);
    }

    [Theory]
    [ChatsSortOrderEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenSortOrderIsInvalid(
        IEnumTransformer<CommonSortOrder> transformer, IEnumMessageTransformer<CommonSortOrder> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortOrder(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortOrder(messageTransformer, request);
    }

    [Theory]
    [ChatsSortTermEmptyWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenSortTermIsInvalid(
        IEnumTransformer<ChatsSortTerm> transformer, IEnumMessageTransformer<ChatsSortTerm> messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithSortTerm(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForSortTerm(messageTransformer, request);
    }

    [Theory]
    [ChatPageTooSmallWithMessageData]
    [ChatPageTooLargeWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenPageIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPage(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPage(messageTransformer, request);
    }

    [Theory]
    [ChatPageSizeTooSmallWithMessageData]
    [ChatPageSizeTooLargeWithMessageData]
    public void TestValidate_ShouldHaveAnError_WhenPageSizeIsInvalid(
        IIntTransformer transformer, IIntMessageTransformer messageTransformer)
    {
        // Arrange
        var request = _requestBuilder.WithPageSize(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldHaveValidationErrorForPageSize(messageTransformer, request);
    }

    [Theory]
    [UserNameEmptyData]
    [UserNameNullData]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenParticipantTwoNameIsValid(
        IStringTransformer transformer)
    {
        // Arrange
        var request = _requestBuilder.WithParticipantTwoName(transformer).Build();

        // Act
        var result = _requestValidator.TestValidate(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }

    [Fact]
    public void TestValidate_ShouldNotHaveAnyValidationsErrors_WhenRequestIsValid()
    {
        // Act
        var result = _requestValidator.TestValidate(_request);

        // Assert
        result.ShouldNotHaveAnyValidationErrorProperties();
    }
}
