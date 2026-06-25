using InstaConnect.Posts.Domain.Features.Users.Helpers;
using InstaConnect.Posts.Domain.Features.Users.Models.Requests;
using InstaConnect.Posts.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Posts.Domain.Tests.Features.Users.Builders;
using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Posts.Domain.Tests.Unit.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Unit.Features.Users.Commands;

public class DeleteUserUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly DeleteUserCommandBuilderFactory _commandBuilderFactory;
	private readonly DeleteUserCommandBuilder _commandBuilder;
	private readonly DeleteUserCommand _command;

	private readonly UserCommandService _service;

	public DeleteUserUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();

		_service = new(UserFactory, UserRepository);

		UserRepository.SetupGetById(_command, User, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldThrowUserNotFoundException_WhenCommandIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetById(_command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheUserRepositoryDeleteAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneDeleteAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.DeleteAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByIdAsync(_command, CancellationToken);
	}
}
