using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Identity.Domain.Features.Users.Helpers;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Builders;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Services;

public class AddUserServiceUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly AddUserCommandBuilderFactory _commandBuilderFactory;
	private readonly AddUserCommandBuilder _commandBuilder;
	private readonly AddUserCommand _command;

	private readonly UserCommandService _service;

	public AddUserServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create();
		_command = _commandBuilder.Build();

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

		Repository.SetupIsEmailUnique(_command, CancellationToken);
		Repository.SetupIsNameUnique(_command, CancellationToken);
		Factory.SetupCreate(_command, User);
		ImageHandler.SetupUpload(_command, CancellationToken);
		EmailConfirmationTokenFactory.SetupCreate(_command, EmailConfirmationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsInvalid()
	{
		// Arrange
		Repository.RemoveIsEmailUnique(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserEmailAlreadyTakenExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsInvalid()
	{
		// Arrange
		Repository.RemoveIsNameUnique(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameAlreadyTakenExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, User);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldReturnResponse_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		var response = await _service.AddAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsEmailUniqueAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsNameUniqueAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldReceiveOneCreate(_command);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		Factory.ShouldReceiveOneCreate(command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheImageHandlerUploadAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await ImageHandler.ShouldReceiveOneUploadAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheImageHandlerUploadAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldReceiveZeroUploadAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneAddAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheRepositoryAddAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneAddAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsyncForUserAdded_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(_command, User, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsyncForUserAdded_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(command, User, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		EmailConfirmationTokenFactory.ShouldReceiveOneCreate(_command, User);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenFactoryCreate_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		EmailConfirmationTokenFactory.ShouldReceiveOneCreate(command, User);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveOneAddAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenRepositoryAddAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveOneAddAsync(command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenAdded_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(_command, EmailConfirmationToken, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenAdded_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(command, EmailConfirmationToken, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenEmailSenderSendAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EmailConfirmationTokenEmailSender.ShouldReceiveOneSendAsync(_command, CancellationToken);
	}

	[Theory]
	[UserProfileImageNullData]
	public async Task AddAsync_ShouldCallTheEmailConfirmationTokenEmailSenderSendAsync_WhenProfileImageIsValid(
		IFormFileTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithProfileImage(transformer).Build();

		// Act
		await _service.AddAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenEmailSender.ShouldReceiveOneSendAsync(command, CancellationToken);
	}
}
