using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Builders;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;
using InstaConnect.Identity.Domain.Tests.Unit.Features.ForgotPasswordTokens.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Unit.Features.ForgotPasswordTokens.Services;

public class AddForgotPasswordTokenServiceUnitTests : BaseForgotPasswordTokenDomainCommandUnitTest
{
	private readonly AddForgotPasswordTokenCommandBuilderFactory _commandBuilderFactory;
	private readonly AddForgotPasswordTokenCommandBuilder _commandBuilder;
	private readonly AddForgotPasswordTokenCommand _command;

	private readonly ForgotPasswordTokenCommandService _service;

	public AddForgotPasswordTokenServiceUnitTests()
	{
		_commandBuilderFactory = new();
		_commandBuilder = _commandBuilderFactory.Create(User);
		_command = _commandBuilder.Build();

		_service = new(
			Mapper,
			PasswordHasher,
			EventPublisher,
			Repository,
			DateTimeProvider,
			IncludeBuilderFactory,
			Factory,
			EmailSender,
			ForgotPasswordTokenRepository);

		Repository.SetupGetByName(_command, User, CancellationToken);
		Factory.SetupCreate(_command, ForgotPasswordToken);
	}

	[Fact]
	public async Task AddAsync_ShouldThrowUserNameNotFoundException_WhenUserNotFound()
	{
		// Arrange
		Repository.RemoveGetByName(_command, User, CancellationToken);

		// Assert
		await _service.ShouldThrowUserNameNotFoundExceptionAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldReturnResponse_WhenCommandIsValid()
	{
		// Act
		var response = await _service.AddAsync(_command, CancellationToken);

		// Assert
		response.ShouldSatisfy(ForgotPasswordToken, _command);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheRepositoryGetByNameAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await Repository.ShouldReceiveOneGetByNameAsync(_command, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheFactoryCreate_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		Factory.ShouldReceiveOneCreate(_command, ForgotPasswordToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheForgotPasswordTokenRepositoryAddAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await ForgotPasswordTokenRepository.ShouldReceiveOneAddAsync(_command, ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheEventPublisherPublishAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EventPublisher.ShouldReceiveOnePublishAsync(_command, ForgotPasswordToken, CancellationToken);
	}

	[Fact]
	public async Task AddAsync_ShouldCallTheForgotPasswordTokenEmailSenderSendAsync_WhenCommandIsValid()
	{
		// Act
		await _service.AddAsync(_command, CancellationToken);

		// Assert
		await EmailSender.ShouldReceiveOneSendAsync(_command, ForgotPasswordToken, CancellationToken);
	}
}
