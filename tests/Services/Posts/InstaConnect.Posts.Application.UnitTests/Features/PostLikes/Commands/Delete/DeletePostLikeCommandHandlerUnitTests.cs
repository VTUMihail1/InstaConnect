using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;
using InstaConnect.PostLikes.Application.UnitTests.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Assertions;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.AddApiRequest;
using InstaConnect.PostLikes.Common.Tests.Features.PostLikes.Utilities.Builders.DeleteCommandRequest;

namespace InstaConnect.PostLikes.Application.UnitTests.Features.PostLikes.Commands.Delete;

public class DeletePostLikeCommandHandlerUnitTests : BasePostLikeApplicationUnitTest
{
    private readonly DeletePostLikeCommandRequestBuilderFactory _requestBuilderFactory;
    private readonly DeletePostLikeCommandRequestBuilder _requestBuilder;
    private readonly DeletePostLikeCommandRequest _request;

    private readonly DeletePostLikeCommandHandler _handler;

    public DeletePostLikeCommandHandlerUnitTests()
    {
        _requestBuilderFactory = new();
        _requestBuilder = _requestBuilderFactory.Create(PostLike);
        _request = _requestBuilder.Build();

        _handler = new(PostLikeService, ApplicationMapper);
    }

    [Fact]
    public async Task Handle_ShouldCallPostLikeServiceDeleteAsync_WhenRequestIsValid()
    {
        // Act
        await _handler.Handle(_request, CancellationToken);

        // Assert
        await PostLikeService.ShouldReceiveOneDeleteAsync(_request, CancellationToken);
    }
}
