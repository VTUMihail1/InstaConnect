using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.PostComments.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.PostComments.Assertions;
using InstaConnect.Posts.Tests.Features.PostComments.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.PostComments.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.PostComments.Commands;

public class UpdatePostCommentIntegrationTests : BasePostCommentDomainCommandIntegrationTest
{
	private readonly UpdatePostCommentCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdatePostCommentCommandBuilder _commandBuilder;
	private readonly UpdatePostCommentCommand _command;

	public UpdatePostCommentIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostComment);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddPostAsync(Post, CancellationToken);
		await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostCommentNotFoundException_WhenPostCommentIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowPostCommentForbiddenException_WhenUserIdIsInvalid()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		await ServiceScope.AddUserAsync(user, CancellationToken);
		var command = _commandBuilder.WithUserId(user.Id).Build();

		// Assert
		await Service.ShouldThrowPostCommentForbiddenExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postComment, _command);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postComment, command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postComment, command);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postComment, command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(_command);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(command);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task UpdateAsync_ShouldUpdatePostComment_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		postComment.ShouldSatisfy(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.UpdateAsync(_command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentUpdatedAsync(postComment, CancellationToken);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentUpdatedAsync(postComment, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentUpdatedAsync(postComment, CancellationToken);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task UpdateAsync_ShouldPublishPostCommentUpdatedEvent_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.UpdateAsync(command, CancellationToken);
		var postComment = await ServiceScope.GetPostCommentByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentUpdatedAsync(postComment, CancellationToken);
	}
}
