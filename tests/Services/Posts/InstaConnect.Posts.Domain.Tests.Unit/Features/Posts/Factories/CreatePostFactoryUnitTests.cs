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

		GuidProvider.SetupNewStringGuid(Post);
		DateTimeProvider.SetupGetOffsetUtcNow(Post);
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
	public void Create_ShouldCallTheGuidProviderNewStringGuid_WhenRequestIsValid()
	{
		// Act
		_factory.Create(Post.UserId, Post.Title, Post.Content);

		// Assert
		GuidProvider.ShouldReceiveOneNewStringGuid();
	}

	[Fact]
	public void Create_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenRequestIsValid()
	{
		// Act
		_factory.Create(Post.UserId, Post.Title, Post.Content);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow();
	}
}
