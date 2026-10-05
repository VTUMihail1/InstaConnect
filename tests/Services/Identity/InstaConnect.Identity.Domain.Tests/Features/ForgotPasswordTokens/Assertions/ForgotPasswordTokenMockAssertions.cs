using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMockAssertions
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow(IOptions<ForgotPasswordTokenOptions> forgotPasswordTokenOptions)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow(forgotPasswordTokenOptions.Value.LifetimeSeconds);
		}

		public void ShouldHaveReceivedOneGetOffsetUtcNow(VerifyForgotPasswordTokenCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void ShouldHaveReceivedOneHash(VerifyForgotPasswordTokenCommand command)
		{
			passwordHasher.ShouldHaveReceivedOne().Hash(command.Password);
		}
	}

	extension(IForgotPasswordTokenFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
		{
			factory.ShouldHaveReceivedOne().Create(forgotPasswordToken.Id.Id);
		}
	}

	extension(IForgotPasswordTokenEmailSender emailSender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
			AddForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOne().SendAsync(command.IsForgotPasswordToken(), cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsForgotPasswordTokenAddedEventRequest(forgotPasswordToken), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			VerifyForgotPasswordTokenCommand command,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsForgotPasswordTokenDeletedEventRequestCollection(forgotPasswordTokens), cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByNameAsync(
			AddForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByNameAsync(command.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			VerifyForgotPasswordTokenCommand command,
			IPasswordHasher passwordHasher,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(command.IsUser(passwordHasher), cancellationToken);
		}
	}

	extension(IForgotPasswordTokenCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsForgotPasswordToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteRangeAsync(command.IsForgotPasswordTokenCollection(), cancellationToken);
		}
	}
}
