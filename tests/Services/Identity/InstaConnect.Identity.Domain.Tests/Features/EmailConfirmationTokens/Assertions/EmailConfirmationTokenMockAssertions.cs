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
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOne().SendAsync(command.IsEmailConfirmationToken(), cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldReceiveOnePublishAsync(
			AddEmailConfirmationTokenCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsEmailConfirmationTokenAddedEventRequest(emailConfirmationToken), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			VerifyEmailConfirmationTokenCommand command,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsEmailConfirmationTokenDeletedEventRequestCollection(emailConfirmationTokens), cancellationToken);
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
				command.IsUserInclude(include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(command.IsUser(), cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenCommandRepository repository)
	{
		public async Task ShouldReceiveOneAddAsync(
			AddEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsEmailConfirmationToken(), cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteRangeAsync(
			VerifyEmailConfirmationTokenCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteRangeAsync(command.IsEmailConfirmationTokenCollection(), cancellationToken);
		}
	}
}
