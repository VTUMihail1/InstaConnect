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

public class AddPostCommentLikeIntegrationTests : BasePostCommentLikeDomainCommandIntegrationTest
{
	private readonly AddPostCommentLikeCommandBuilderFactory _commandBuilderFactory;
	private readonly AddPostCommentLikeCommandBuilder _commandBuilder;
	private readonly AddPostCommentLikeCommand _command;

	public AddPostCommentLikeIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(PostComment, User);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
		await ServiceScope.AddPostAsync(Post, CancellationToken);
		await ServiceScope.AddPostCommentAsync(PostComment, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostAsync(Post, CancellationToken);

		// Assert
		await Service.ShouldThrowPostNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostCommentNotFoundException_WhenCommentIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeletePostCommentAsync(PostComment, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNotFoundException_WhenUserIdIsInvalid()
	{
		// Arrange
		await ServiceScope.DeleteUserAsync(User, CancellationToken);

		// Assert
		await Service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExists()
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);

		// Assert
		await Service.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(_command, CancellationToken);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
		var command = _commandBuilder.WithId(transformer).Build();

		// Assert
		await Service.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndCommentIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Assert
		await Service.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowPostCommentLikeAlreadyExistsException_WhenPostCommentLikeAlreadyExistsAndUserIdIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddPostCommentLikeAsync(PostCommentLike, CancellationToken);
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Assert
		await Service.ShouldThrowPostCommentLikeAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postCommentLike, _command);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postCommentLike, command);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postCommentLike, command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(postCommentLike, command);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(_command);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(command);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPostCommentLike_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		postCommentLike.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeAddedAsync(postCommentLike, CancellationToken);
	}

	[Theory]
	[PostIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenCommandAndIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeAddedAsync(postCommentLike, CancellationToken);
	}

	[Theory]
	[PostCommentIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenCommandAndCommentIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithCommentId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeAddedAsync(postCommentLike, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostCommentLikeAddedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var postCommentLike = await ServiceScope.GetPostCommentLikeByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostCommentLikeAddedAsync(postCommentLike, CancellationToken);
	}
}
