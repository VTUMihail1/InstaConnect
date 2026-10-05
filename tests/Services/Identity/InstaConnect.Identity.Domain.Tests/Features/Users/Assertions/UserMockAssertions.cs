using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Events.Features.Events.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(AddUserCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.Name,
				command.FirstName,
				command.LastName,
				command.Email,
				command.Password);
		}
	}

	extension(IPasswordHasher passwordHasher)
	{
		public void ShouldHaveReceivedOneHash(string password)
		{
			passwordHasher.ShouldHaveReceivedOne().Hash(password);
		}
	}

	extension(IImageHandler imageHandler)
	{
		public async Task ShouldHaveReceivedOneUploadAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedOne().UploadAsync(command.ProfileImage!, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUploadAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedOne().UploadAsync(command.ProfileImage!, cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroUploadAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedZero().UploadAsync(command.ProfileImage!, cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroUploadAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedZero().UploadAsync(command.ProfileImage!, cancellationToken);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldHaveReceivedOneGetOffsetUtcNow(UpdateUserCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneIsEmailUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsEmailUniqueAsync(command.Email, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsEmailUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsEmailUniqueAsync(command.Email, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsNameUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsNameUniqueAsync(command.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsNameUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsNameUniqueAsync(command.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UpdateUserCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				include,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneAddAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsUser(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneUpdateAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(command.IsUser(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(command.IsUser(), cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldHaveReceivedOneGetAllAsync(
			GetAllUsersQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				query.Filter,
				query.Sorting,
				query.Pagination,
				query.Current,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetTotalCountAsync(
			GetAllUsersQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			GetUserByIdQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				query.Id,
				query.Current,
				cancellationToken);
		}
	}

	extension(IEventPublisher eventPublisher)
	{
		public async Task ShouldHaveReceivedOnePublishAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsUserAddedEventRequest(user), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsUserUpdatedEventRequest(user), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsUserDeletedEventRequest(user), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishAsync(
			AddUserCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsEmailConfirmationTokenAddedEventRequest(emailConfirmationToken), cancellationToken);
		}

		public async Task ShouldHaveReceivedOnePublishEmailConfirmationTokenDeletedAsync(
			UpdateUserCommand command,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(command.IsEmailConfirmationTokenDeletedEventRequestCollection(emailConfirmationTokens), cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroPublishEmailConfirmationTokenDeletedAsync(
			UpdateUserCommand command,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedZero().PublishAsync(command.IsEmailConfirmationTokenDeletedEventRequestCollection(emailConfirmationTokens), cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
			AddUserCommand command,
			User user)
		{
			factory.ShouldHaveReceivedOne().Create(user.Id);
		}
	}

	extension(IEmailConfirmationTokenCommandRepository repository)
	{
		public async Task ShouldHaveReceivedOneAddAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(command.IsEmailConfirmationToken(), cancellationToken);
		}

		public async Task ShouldHaveReceivedOneDeleteRangeAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteRangeAsync(command.IsEmailConfirmationTokenCollection(), cancellationToken);
		}

		public async Task ShouldHaveReceivedZeroDeleteRangeAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedZero().DeleteRangeAsync(command.IsEmailConfirmationTokenCollection(), cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenEmailSender emailSender)
	{
		public async Task ShouldHaveReceivedOneSendAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOne().SendAsync(command.IsEmailConfirmationToken(), cancellationToken);
		}
	}
}
