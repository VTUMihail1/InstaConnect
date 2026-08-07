using InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserFactory factory)
	{
		public void ShouldReceiveOneCreate(
			AddUserCommand command)
		{
			factory.ShouldHaveReceivedOne().Create(
				command.Id,
				command.FirstName,
				command.LastName,
				command.Name,
				command.Email,
				command.ProfileImage,
				command.CreatedAtUtc,
				command.UpdatedAtUtc);
		}
	}

	extension(IUserCommandRepository repository)
	{
		public async Task ShouldReceiveOneAddAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().AddAsync(UserDomainMatcher.IsUser(command), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().UpdateAsync(UserDomainMatcher.IsUser(command), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().DeleteAsync(UserDomainMatcher.IsUser(command), cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			DeleteUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneIsNameUniqueAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsNameUniqueAsync(request.Name, cancellationToken);
		}

		public async Task ShouldReceiveOneIsNameUniqueAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsNameUniqueAsync(request.Name, cancellationToken);
		}

		public async Task ShouldReceiveOneIsEmailUniqueAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsEmailUniqueAsync(request.Email, cancellationToken);
		}

		public async Task ShouldReceiveOneIsEmailUniqueAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsEmailUniqueAsync(request.Email, cancellationToken);
		}
	}
}
