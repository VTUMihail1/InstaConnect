using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;
using InstaConnect.PostCommentLikes.Application.UnitTests.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Assertions;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostCommentLikes.Common.Tests.Features.PostCommentLikes.Utilities.Builders.DeleteCommandRequest;

namespace InstaConnect.PostCommentLikes.Application.UnitTests.Features.PostCommentLikes.Commands.Delete;

public class DeletePostCommentLikeCommandHandlerUnitTests : BasePostCommentLikeApplicationUnitTest
{
    private readonly DeletePostCommentLikeCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostCommentLikeCommandRequestBuilder _requestBuilder;
    private readonly DeletePostCommentLikeCommandRequest _request;

    private readonly DeletePostCommentLikeCommandHandler _handler;

    public DeletePostCommentLikeCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostCommentLike);
        _request = _requestBuilder.Build();

        _handler = new(ApplicationMapper, PostCommentLikeService);
    }

    [Fact]
    public async Task Handle_ShouldCallPostCommentLikeServiceDeleteAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostCommentLikeService.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
    }
}
