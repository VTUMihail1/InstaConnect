using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Users.Builders;
using InstaConnect.Posts.Domain.Tests.Integration.Features.Users.Utilities;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Id;
using InstaConnect.Posts.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Integration.Features.Users.Commands;

public class AddUserIntegrationTests : BaseUserDomainCommandIntegrationTest
{
	private readonly AddUserCommandBuilderFactory _commandBuilderFactory;
	private readonly AddUserCommandBuilder _commandBuilder;
	private readonly AddUserCommand _command;

	public AddUserIntegrationTests(PostsWebApplicationFactory webApplicationFactory)
		: base(webApplicationFactory)
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create();
		_command = _commandBuilder.Build();
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserAlreadyExistsException_WhenCommandIsInvalid()
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var command = _commandBuilder.WithId(User.Id).Build();

		// Assert
		await UserService.ShouldThrowUserAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserIdDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserAlreadyExistsException_WhenIdIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var command = _commandBuilder.WithId(User.Id, transformer).Build();

		// Assert
		await UserService.ShouldThrowUserAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyExistsException_WhenCommandIsInvalid()
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Assert
		await UserService.ShouldThrowUserEmailAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyExistsException_WhenEmailIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Assert
		await UserService.ShouldThrowUserEmailAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameAlreadyExistsException_WhenCommandIsInvalid()
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var command = _commandBuilder.WithName(User.Name).Build();

		// Assert
		await UserService.ShouldThrowUserNameAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task AddAsync_ShouldThrowUserNameAlreadyExistsException_WhenNameIsInvalid(
		IStringTransformer transformer)
	{
		// Arrange
		await ServiceScope.AddUserAsync(User, CancellationToken);
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Assert
		await UserService.ShouldThrowUserNameAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await UserService.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		response.ShouldSatisfy(user, _command);
	}

	[Fact]
	public async Task AddAsync_ShouldAddUser_WhenCommandIsValid()
	{
		// Act
		var response = await UserService.AddAsync(_command, CancellationToken);
		var user = await ServiceScope.GetUserByIdAsync(response, CancellationToken);

		// Assert
		user.ShouldSatisfy(_command);
	}
}
