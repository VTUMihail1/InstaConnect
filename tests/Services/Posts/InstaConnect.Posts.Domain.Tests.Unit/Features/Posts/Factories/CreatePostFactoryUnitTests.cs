using InstaConnect.Common.Domain.Tests.Features.Assertions;
using InstaConnect.Posts.Domain.Features.Posts.Helpers;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Posts.Factories;

public class CreatePostFactoryUnitTests : BasePostDomainCommandUnitTest
{
	private readonly PostFactory _factory;

	public CreatePostFactoryUnitTests()
	{
		_factory = new(GuidProvider, DateTimeProvider);

		GuidProvider.SetupNewGuid(Post);
		DateTimeProvider.SetupNewGuid(Post);
	}

	[Fact]
	public void Create_ShouldCreatePost_WhenRequestIsValid()
	{
		// Act
		var response = _factory.Create(Post.UserId, Post.Title, Post.Content);

		// Assert
		response.ShouldSatisfy(Post);
	}

	[Fact]
	public void Create_ShouldCallTheGuidProviderNewGuid_WhenRequestIsValid()
	{
		// Act
		_factory.Create(Post.UserId, Post.Title, Post.Content);

		// Assert
		GuidProvider.ShouldReceiveOneNewGuid();
	}

	[Fact]
	public void Create_ShouldCallTheGuidProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(Post.UserId, Post.Title, Post.Content);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow();
	}
}
