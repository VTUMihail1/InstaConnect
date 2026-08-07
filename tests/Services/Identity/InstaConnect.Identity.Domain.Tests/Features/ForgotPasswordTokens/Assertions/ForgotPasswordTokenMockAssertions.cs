using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Tests.Features.ForgotPasswordTokens.Assertions;

public static class ForgotPasswordTokenMockAssertions
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldReceiveOneGetOffsetUtcNow(IOptions<ForgotPasswordTokenOptions> forgotPasswordTokenOptions)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow(forgotPasswordTokenOptions.Value.LifetimeSeconds);
		}

		public void ShouldReceiveOneGetOffsetUtcNow(VerifyForgotPasswordTokenCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void ShouldReceiveOneHash(VerifyForgotPasswordTokenCommand command)
		{
			passwordHasher.ShouldHaveReceivedOne().Hash(command.Password);
		}
	}

	extension(IForgotPasswordTokenFactory factory)
	{
		public void ShouldReceiveOneCreate(AddForgotPasswordTokenCommand command, ForgotPasswordToken forgotPasswordToken)
		{
			factory.ShouldHaveReceivedOne().Create(forgotPasswordToken.Id.Id);
		}
	}

	extension(IForgotPasswordTokenEmailSender emailSender)
	{
		public async Task ShouldReceiveOneSendAsync(
			AddForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOne().SendAsync(ForgotPasswordTokenDomainMatcher.IsForgotPasswordToken(command, forgotPasswordToken), cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldReceiveOnePublishAsync(
			AddForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(ForgotPasswordTokenDomainMatcher.IsForgotPasswordTokenAddedEventRequest(command, forgotPasswordToken), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			VerifyForgotPasswordTokenCommand command,
			ICollection<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(ForgotPasswordTokenDomainMatcher.IsForgotPasswordTokenDeletedEventRequestCollection(command, forgotPasswordTokens), cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByNameAsync(
			AddForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByNameAsync(command.Name, cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id.Id,
				ForgotPasswordTokenDomainMatcher.IsUserInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			VerifyForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(user, cancellationToken);
		}
	}

	extension(IForgotPasswordTokenCommandRepository repository)
	{
		public async Task ShouldReceiveOneAddAsync(
			AddForgotPasswordTokenCommand command,
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(ForgotPasswordTokenDomainMatcher.IsForgotPasswordToken(command, forgotPasswordToken), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			VerifyForgotPasswordTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteRangeAsync(
			VerifyForgotPasswordTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteRangeAsync(user.ForgotPasswordTokens, cancellationToken);
		}
	}
}
