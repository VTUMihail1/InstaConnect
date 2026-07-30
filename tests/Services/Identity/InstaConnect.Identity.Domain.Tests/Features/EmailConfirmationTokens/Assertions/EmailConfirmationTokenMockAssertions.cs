using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMockAssertions
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldReceiveOneGetOffsetUtcNow(IOptions<EmailConfirmationTokenOptions> emailConfirmationTokenOptions)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow(emailConfirmationTokenOptions.Value.LifetimeSeconds);
		}

		public void ShouldReceiveOneGetOffsetUtcNow(VerifyEmailConfirmationTokenCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IEmailConfirmationTokenFactory factory)
	{
		public void ShouldReceiveOneCreate(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
		{
			factory.ShouldHaveReceivedOne().Create(emailConfirmationToken.Id.Id);
		}
	}

	extension(IEmailConfirmationTokenEmailSender emailSender)
	{
		public async Task ShouldReceiveOneSendAsync(
			AddEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOne().SendAsync(EmailConfirmationTokenDomainMatcher.IsEmailConfirmationToken(command, emailConfirmationToken), cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldReceiveOnePublishAsync(
			AddEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(EmailConfirmationTokenDomainMatcher.IsEmailConfirmationTokenAddedEventRequest(command, emailConfirmationToken), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			VerifyEmailConfirmationTokenCommand command,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(EmailConfirmationTokenDomainMatcher.IsEmailConfirmationTokenDeletedEventRequestCollection(command, emailConfirmationTokens), cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldReceiveOneGetByNameAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByNameAsync(command.Name, cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id.Id,
				EmailConfirmationTokenDomainMatcher.IsUserInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			VerifyEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(user, cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenCommandRepository repository)
	{
		public async Task ShouldReceiveOneAddAsync(
			AddEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(EmailConfirmationTokenDomainMatcher.IsEmailConfirmationToken(command, emailConfirmationToken), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteRangeAsync(
			VerifyEmailConfirmationTokenCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteRangeAsync(user.EmailConfirmationTokens, cancellationToken);
		}
	}
}
