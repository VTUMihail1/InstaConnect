using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Identity.Domain.Features.Users.Helpers;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Builders;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Services;

public class UpdateUserServiceUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly UpdateUserCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdateUserCommandBuilder _commandBuilder;
	private readonly UpdateUserCommand _command;

	private readonly UserInclude _include;

	private readonly UserCommandService _service;

	public UpdateUserServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();

		_include = IncludeBuilderFactory.Create().WithEmailConfirmationTokens().Build();

		_service = new(
			Factory,
			Mapper,
			ImageHandler,
			EventPublisher,
			Repository,
			DateTimeProvider,
			IncludeBuilderFactory,
			EmailConfirmationTokenFactory,
			EmailConfirmationTokenEmailSender,
			EmailConfirmationTokenRepository);

		Repository.SetupGetById(_command, _include, User, CancellationToken);
		Repository.SetupIsEmailUnique(_command, CancellationToken);
		Repository.SetupIsNameUnique(_command, CancellationToken);
		ImageHandler.SetupUpload(_command, CancellationToken);
		DateTimeProvider.SetupGetOffsetUtcNow(_command, User);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNotFoundException_WhenIdIsInvalid()
	{
		// Arrange
		Repository.RemoveGetById(_command, _include, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsChangedAndNotUnique()
	{
		// Arrange
		Repository.RemoveIsEmailUnique(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserEmailAlreadyTakenExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsChangedAndNotUnique()
	{
		// Arrange
		Repository.RemoveIsNameUnique(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameAlreadyTakenExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotThrowUserEmailAlreadyTakenException_WhenEmailIsNotChangedAndNotUnique()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();
		Repository.RemoveIsEmailUnique(command, CancellationToken);

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotThrowUserNameAlreadyTakenException_WhenNameIsNotChangedAndNotUnique()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();
		Repository.RemoveIsNameUnique(command, CancellationToken);

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, _command);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(User, command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(_command, _include, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsEmailUniqueAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsNameUniqueAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenEmailIsChanged()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveOneDeleteRangeAsync(_command, User, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenEmailIsChangedAndProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveOneDeleteRangeAsync(command, User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenEmailIsChanged()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishEmailConfirmationTokenDeletedAsync(_command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenEmailIsChangedAndProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenEmailIsNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveZeroDeleteRangeAsync(_command, User, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldNotCallTheImageHandlerUploadAsync_WhenEmailIsNotChangedAndProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveZeroDeleteRangeAsync(command, User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenEmailIsNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveZeroPublishEmailConfirmationTokenDeletedAsync(command, EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldNotCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveZeroPublishEmailConfirmationTokenDeletedAsync(command, EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await ImageHandler.ShouldReceiveOneUploadAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldNotCallTheImageHandlerUploadAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldReceiveZeroUploadAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow(_command);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneUpdateAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneUpdateAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(_command, User, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(command, User, CancellationToken);
	}
}
