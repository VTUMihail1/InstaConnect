using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserFactory userFactory)
	{
		public void ShouldReceiveOneCreate(
			AddUserCommand command)
		{
			userFactory.ShouldHaveReceivedOne().Create(
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

	extension(IUserCommandRepository userRepository)
	{
		public async Task ShouldReceiveOneAddAsync(
			AddUserCommand command,
			CancellationToken cancellationToken)
		{
			await userRepository.ShouldHaveReceivedOne().AddAsync(UserMatcher.IsUser(command), cancellationToken);
		}

		public async Task ShouldReceiveOneUpdateAsync(
			UpdateUserCommand command,
			CancellationToken cancellationToken)
		{
			await userRepository.ShouldHaveReceivedOne().UpdateAsync(UserMatcher.IsUser(command), cancellationToken);
		}

		public async Task ShouldReceiveOneDeleteAsync(
			DeleteUserCommand command,
			CancellationToken cancellationToken)
		{
			await userRepository.ShouldHaveReceivedOne().DeleteAsync(UserMatcher.IsUser(command), cancellationToken);
		}

		public async Task ShouldReceiveOneExistsByIdAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await userRepository.ShouldHaveReceivedOne().ExistsByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await userRepository.ShouldHaveReceivedOne().GetByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneGetByIdAsync(
			DeleteUserCommand request,
			CancellationToken cancellationToken)
		{
			await userRepository.ShouldHaveReceivedOne().GetByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldReceiveOneIsNameUniqueAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await userRepository.ShouldHaveReceivedOne().IsNameUniqueAsync(request.Name, cancellationToken);
		}

		public async Task ShouldReceiveOneIsNameUniqueAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await userRepository.ShouldHaveReceivedOne().IsNameUniqueAsync(request.Name, cancellationToken);
		}

		public async Task ShouldReceiveOneIsEmailUniqueAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await userRepository.ShouldHaveReceivedOne().IsEmailUniqueAsync(request.Email, cancellationToken);
		}

		public async Task ShouldReceiveOneIsEmailUniqueAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await userRepository.ShouldHaveReceivedOne().IsEmailUniqueAsync(request.Email, cancellationToken);
		}
	}
}
