using InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;
using InstaConnect.Common.Tests.Features.DataAttributes.Strings.Base;
using InstaConnect.Identity.Domain.Features.Users.Helpers;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.Users.Builders;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Utilities;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Email;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.Name;
using InstaConnect.Identity.Tests.Features.Users.DataAttributes.ProfileImage;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.Users.Services;

public class UpdateUserCommandServiceUnitTests : BaseUserDomainCommandUnitTest
{
	private readonly UpdateUserCommandBuilderFactory _commandBuilderFactory;
	private readonly UpdateUserCommandBuilder _commandBuilder;
	private readonly UpdateUserCommand _command;

	private readonly UserInclude _include;

	private readonly UserCommandService _service;

	public UpdateUserCommandServiceUnitTests()
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
	public async Task UpdateAsync_ShouldThrowUserEmailAlreadyTakenException_WhenEmailIsInvalid()
	{
		// Arrange
		Repository.RemoveIsEmailUnique(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserEmailAlreadyTakenExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldThrowUserNameAlreadyTakenException_WhenNameIsInvalid()
	{
		// Arrange
		Repository.RemoveIsNameUnique(_command, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameAlreadyTakenExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(_command, User);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Fact]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldReturnResponse_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		var response = await _service.UpdateAsync(command, CancellationToken);

		// Assert
		response.ShouldSatisfy(command, User);
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
		response.ShouldSatisfy(command, User);
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
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(command, _include, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryGetByIdAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByIdAsync(command, _include, CancellationToken);
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
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsEmailUniqueAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsEmailUniqueAsync(command, CancellationToken);
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
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryIsNameUniqueAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneIsNameUniqueAsync(command, CancellationToken);
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
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveOneDeleteRangeAsync(_command, User, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveOneDeleteRangeAsync(command, User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveOneDeleteRangeAsync(command, User, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveOneDeleteRangeAsync(command, User, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveOneDeleteRangeAsync(command, User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveZeroDeleteRangeAsync(command, User, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldNotCallTheEmailConfirmationTokenRepositoryDeleteRangeAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EmailConfirmationTokenRepository.ShouldReceiveZeroDeleteRangeAsync(command, User, CancellationToken);
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
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishEmailConfirmationTokenDeletedAsync(_command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldNotCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveZeroPublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldNotCallTheEventPublisherPublishAsyncForEmailConfirmationTokenDeleted_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveZeroPublishEmailConfirmationTokenDeletedAsync(command, User.EmailConfirmationTokens, CancellationToken);
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
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenCommandIsValid()
	{
		// Act
		await _service.UpdateAsync(_command, CancellationToken);

		// Assert
		await ImageHandler.ShouldReceiveOneUploadAsync(_command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldReceiveOneUploadAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldReceiveOneUploadAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldReceiveOneUploadAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldReceiveOneUploadAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldReceiveOneUploadAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheImageHandlerUploadAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await ImageHandler.ShouldReceiveOneUploadAsync(command, CancellationToken);
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
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow(command);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow(command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow(command);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow(command);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheDateTimeProviderGetOffsetUtcNow_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		DateTimeProvider.ShouldReceiveOneGetOffsetUtcNow(command);
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
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneUpdateAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneUpdateAsync(command, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneUpdateAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneUpdateAsync(command, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneUpdateAsync(command, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheRepositoryUpdateAsync_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneUpdateAsync(command, CancellationToken);
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
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenNameIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(command, User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenNameHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(command, User, CancellationToken);
	}

	[Theory]
	[UserNameDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenNameIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithName(User.Name, transformer).Build();
		Repository.SetupIsNameUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(command, User, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenEmailIsValid(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(command, User, CancellationToken);
	}

	[Fact]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenEmailHasNotChanged()
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email).Build();

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(command, User, CancellationToken);
	}

	[Theory]
	[UserEmailDifferentCaseData]
	public async Task UpdateAsync_ShouldCallTheEventPublisherPublishAsyncForUserUpdated_WhenEmailIsValidAndHasNotChanged(
		IStringTransformer transformer)
	{
		// Arrange
		var command = _commandBuilder.WithEmail(User.Email, transformer).Build();
		Repository.SetupIsEmailUnique(command, CancellationToken);

		// Act
		await _service.UpdateAsync(command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(command, User, CancellationToken);
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
