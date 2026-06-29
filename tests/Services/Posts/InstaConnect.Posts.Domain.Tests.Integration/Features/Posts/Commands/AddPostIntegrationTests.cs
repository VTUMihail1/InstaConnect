using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Posts.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Posts.Assertions;
using InstaConnect.Posts.Tests.Features.Posts.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Posts.Commands;

public class AddPostIntegrationTests : BasePostDomainCommandIntegrationTest
{
	private readonly AddPostCommandBuilderFactory _commandBuilderFactory;
	private readonly AddPostCommandBuilder _commandBuilder;
	private readonly AddPostCommand _command;

	public AddPostIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();
	}

	protected override async Task OnInitializeAsync()
	{
		await ServiceScope.AddUserAsync(User, CancellationToken);
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
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var post = await ServiceScope.GetPostByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(post, _command);
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
		var post = await ServiceScope.GetPostByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(post, command);
	}

	[Fact]
	public async Task AddAsync_ShouldAddPost_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var post = await ServiceScope.GetPostByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(_command);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldAddPost_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var post = await ServiceScope.GetPostByIdAsync(response, CancellationToken);

		// Assert
		post.ShouldSatisfy(command);
	}

	[Fact]
	public async Task AddAsync_ShouldPublishPostAddedEvent_WhenCommandIsValid()
	{
		// Act
		var response = await Service.AddAsync(_command, CancellationToken);
		var post = await ServiceScope.GetPostByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostAddedAsync(post, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldPublishPostAddedEvent_WhenCommandAndUserIdAreValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithUserId(transformer).Build();

		// Act
		var response = await Service.AddAsync(command, CancellationToken);
		var post = await ServiceScope.GetPostByIdAsync(response, CancellationToken);

		// Assert
		await EventHarness.ShouldHavePublishedPostAddedAsync(post, CancellationToken);
	}
}
