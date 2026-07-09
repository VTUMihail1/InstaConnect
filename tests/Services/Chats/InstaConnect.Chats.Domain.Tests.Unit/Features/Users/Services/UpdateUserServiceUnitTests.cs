using InstaConnect.Chats.Domain.Features.Users.Helpers;
using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Chats.Domain.Tests.Features.Users.Builders;
using InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Chats.Domain.Tests.Unit.Features.Users.Utilities;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Chats.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;

namespace InstaConnect.Chats.Domain.Tests.Unit.Features.Users.Services;

public class UpdateUserServiceUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly UpdateUserCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdateUserCommandBuilder _commandBuilder;
	private readonly UpdateUserCommand _command;

	private readonly UserCommandService _service;

	public UpdateUserServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();

		_service = new(UserFactory, UserRepository);

		UserRepository.SetupGetById(_command, User, CancellationToken);
		UserRepository.SetupIsNameUnique(_command, User, CancellationToken);
		UserRepository.SetupIsEmailUnique(_command, User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNotFoundException_WhenCommandIsInvalid()
	{
		// Arrange
		UserRepository.RemoveGetById(_command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserEmailAlreadyExistsException_WhenCommandIsInvalid()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		var command = _commandBuilder.WithEmail(user.Email).Build();
		UserRepository.RemoveIsEmailUnique(command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserEmailAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNameAlreadyExistsException_WhenCommandIsInvalid()
	{
		// Arrange
		var user = UserBuilderFactory.Create().Build();
		var command = _commandBuilder.WithName(user.Name).Build();
		UserRepository.RemoveIsNameUnique(command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameAlreadyExistsExceptionAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, _command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByIdAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByIdAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByIdAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByIdAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByIdAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneGetByIdAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByNameAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneIsNameUniqueAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByNameAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByNameAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByNameAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByNameAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByEmailAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneIsEmailUniqueAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByEmailAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByEmailAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByEmailAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheUserRepositoryGetByEmailAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await UserRepository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
	}
}
