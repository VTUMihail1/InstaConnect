using InstaConnect.Common.Domain.Tests.Features.Assertions;
using InstaConnect.Posts.Domain.Features.PostComments.Helpers;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.PostComments.Factories;

public class CreatePostCommentFactoryUnitTests : BasePostCommentDomainCommandUnitTest
{
	private readonly PostCommentFactory _factory;

	public CreatePostCommentFactoryUnitTests()
	{
		_factory = new(GuidProvider, DateTimeProvider);

		GuidProvider.SetupNewGuid(PostComment);
		DateTimeProvider.SetupNewGuid(PostComment);
	}

	[Fact]
	public void Create_ShouldCreatePostComment_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(PostComment.Id.Id, PostComment.UserId, PostComment.Content);

		// Assert
		response.ShouldSatisfy(PostComment);
	}

	[Fact]
	public void Create_ShouldCallTheGuidProviderNewGuid_WhenRequestIsValid()
	{
		// Act
		_factory.Create(PostComment.Id.Id, PostComment.UserId, PostComment.Content);

		// Assert
		GuidProvider.ShouldReceiveOneNewGuid();
	}

	[Fact]
	public void Create_ShouldCallTheGuidProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(PostComment.Id.Id, PostComment.UserId, PostComment.Content);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow();
	}
}
