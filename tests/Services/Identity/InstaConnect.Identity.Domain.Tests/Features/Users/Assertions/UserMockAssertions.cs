using InstaConnect.Common.Domain.Features.DateTimes.Abstractions;
using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Events.Features.Common.Abstractions;
using InstaConnect.Identity.Domain.Features.Common.Helpers;
using InstaConnect.Identity.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Domain.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserFactory factory)
	{
		public void ShouldReceiveOneCreate(AddUserCommand command)
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
		public void ShouldReceiveOneHash(string password)
		{
			passwordHasher.ShouldHaveReceivedOne().Hash(password);
		}
	}

	extension(IImageHandler imageHandler)
	{
		public async Task ShouldReceiveOneUploadAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedOne().UploadAsync(command.ProfileImage!, cancellationToken);
		}

		public async Task ShouldReceiveOneUploadAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedOne().UploadAsync(command.ProfileImage!, cancellationToken);
		}

		public async Task ShouldReceiveZeroUploadAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedZero().UploadAsync(command.ProfileImage!, cancellationToken);
		}

		public async Task ShouldReceiveZeroUploadAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await imageHandler.ShouldHaveReceivedZero().UploadAsync(command.ProfileImage!, cancellationToken);
		}
	}

	extension(IDateTimeProvider dateTimeProvider)
	{
		public void ShouldReceiveOneGetOffsetUtcNow(UpdateUserCommand command)
		{
			dateTimeProvider.ShouldHaveReceivedOne().GetOffsetUtcNow();
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldReceiveOneIsEmailUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsEmailUniqueAsync(command.Email, cancellationToken);
		}

		public async Task ShouldReceiveOneIsEmailUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsEmailUniqueAsync(command.Email, cancellationToken);
		}

		public async Task ShouldReceiveOneIsNameUniqueAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsNameUniqueAsync(command.Name, cancellationToken);
		}

		public async Task ShouldReceiveOneIsNameUniqueAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsNameUniqueAsync(command.Name, cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			UpdateUserCommand command,
			UserInclude include,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(
				command.Id,
				UserMatcher.IsUserInclude(command, include),
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(command.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneAddAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(UserMatcher.IsUser(command), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(UserMatcher.IsUser(command), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(UserMatcher.IsUser(command), cancellationToken);
		}
	}

	extension(IUserQueryRepository repository)
	{
		public async Task ShouldReceiveOneGetAllAsync(
			GetAllUsersQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetAllAsync(
				query.Filter,
				query.Current,
				query.Sorting,
				query.Pagination,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetTotalCountAsync(
			GetAllUsersQuery query,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetTotalCountAsync(
				query.Filter,
				cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
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
		public async Task ShouldReceiveOnePublishAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(UserMatcher.IsUserAddedEventRequest(command, user), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(UserMatcher.IsUserUpdatedEventRequest(command, user), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			DeleteUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(UserMatcher.IsUserDeletedEventRequest(command, user), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishAsync(
			AddUserCommand command,
			EmailConfirmationToken emailConfirmationToken,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(UserMatcher.IsEmailConfirmationTokenAddedEventRequest(command, emailConfirmationToken), cancellationToken);
		}

		public async Task ShouldReceiveOnePublishEmailConfirmationTokenDeletedAsync(
			UpdateUserCommand command,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedOne().PublishAsync(UserMatcher.IsEmailConfirmationTokenDeletedEventRequestCollection(command, emailConfirmationTokens), cancellationToken);
		}

		public async Task ShouldReceiveZeroPublishEmailConfirmationTokenDeletedAsync(
			UpdateUserCommand command,
			ICollection<EmailConfirmationToken> emailConfirmationTokens,
			CancellationToken cancellationToken)
		{
			await eventPublisher.ShouldHaveReceivedZero().PublishAsync(UserMatcher.IsEmailConfirmationTokenDeletedEventRequestCollection(command, emailConfirmationTokens), cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenFactory factory)
	{
		public void ShouldReceiveOneCreate(
			AddUserCommand command,
			User user)
		{
			factory.ShouldHaveReceivedOne().Create(user.Id);
		}
	}

	extension(IEmailConfirmationTokenCommandRepository repository)
	{
		public async Task ShouldReceiveOneAddAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(UserMatcher.IsEmailConfirmationToken(command, user), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteRangeAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteRangeAsync(user.EmailConfirmationTokens, cancellationToken);
		}

		public async Task ShouldReceiveZeroDeleteRangeAsync(
			UpdateUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedZero().DeleteRangeAsync(user.EmailConfirmationTokens, cancellationToken);
		}
	}

	extension(IEmailConfirmationTokenEmailSender emailSender)
	{
		public async Task ShouldReceiveOneSendAsync(
			AddUserCommand command,
			User user,
			CancellationToken cancellationToken)
		{
			await emailSender.ShouldHaveReceivedOne().SendAsync(UserMatcher.IsEmailConfirmationToken(command, user), cancellationToken);
		}
	}
}
