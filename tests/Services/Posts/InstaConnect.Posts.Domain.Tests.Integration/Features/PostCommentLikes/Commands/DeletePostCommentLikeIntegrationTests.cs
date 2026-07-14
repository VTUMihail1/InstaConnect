using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostCommentLikes.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Assertions;
using InstaConnect.Posts.Tests.Features.PostCommentLikes.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostCommentLikes.Commands;

public class DeletePostCommentLikeIntegrationTests : BasePostCommentLikeDomainCommandIntegrationTest
{
	private readonly DeletePostCommentLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly DeletePostCommentLikeCommandBuilder _commandBuilder;
	private readonly DeletePostCommentLikeCommand _command;

	public DeletePostCommentLikeIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostCommentLike);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddPostAsync(Post, CancellationToken);
		await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentNotFoundException_WhenCommentIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowPostCommentLikeNotFoundException_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentLikeAsync(PostCommentLike, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentLikeNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(PostCommentLike.Id, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(PostCommentLike.Id, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(PostCommentLike.Id, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldDeletePostCommentLike_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(PostCommentLike.Id, CancellationToken);

		// Assert
		postCommentLike.ShouldBeNull();
	}

	[Fact]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenCommandIsValid()
	{
		// Act
		await Service.DeleteAsync(_command, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeDeletedAsync(_command, PostCommentLike, CancellationToken);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeDeletedAsync(command, PostCommentLike, CancellationToken);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeDeletedAsync(command, PostCommentLike, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task DeleteAsync_ShouldPublishPostCommentLikeDeletedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		await Service.DeleteAsync(command, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeDeletedAsync(command, PostCommentLike, CancellationToken);
	}
}
