using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Utilities;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenMockAssertions
{
	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow(IOptions<EmailConfirmationTokenOptions> emailConfirmationTokenOptions)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow(emailConfirmationTokenOptions.Value.LifetimeSeconds);
		}

		public void ShouldHaveReceivedOneGetOffsetUtcNow(VerifyEmailConfirmationTokenCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IEmailConfirmationTokenFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(AddEmailConfirmationTokenCommand command, EmailConfirmationToken emailConfirmationToken)
		{
			factory.ShouldHaveReceivedOne().Create(emailConfirmationToken.Id.Id);
		}
	}

	extension(IEmailConfirmationTokenEmailSender emailSender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOne().SendAsync(command.IsEmailConfirmationToken(), cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsEmailConfirmationTokenAddedEventRequest(emailConfirmationToken), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			VerifyEmailConfirmationTokenCommand command,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsEmailConfirmationTokenDeletedEventRequestCollection(emailConfirmationTokens), cancellationToken);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetByNameAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByNameAsync(command.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(command.IsUser(), cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsEmailConfirmationToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteRangeAsync(command.IsEmailConfirmationTokenCollection(), cancellationToken);
		}
	}
}
