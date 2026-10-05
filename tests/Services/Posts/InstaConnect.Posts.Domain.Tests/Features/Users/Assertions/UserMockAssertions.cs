using InstaConnect.Posts.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Domain.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
	extension(IUserFactory factory)
	{
		public void ShouldHaveReceivedOneCreate(
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

		public async Task ShouldHaveReceivedOneExistsByIdAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().ExistsByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneGetByIdAsync(
			DeleteUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().GetByIdAsync(request.Id, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsNameUniqueAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsNameUniqueAsync(request.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsNameUniqueAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsNameUniqueAsync(request.Name, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsEmailUniqueAsync(
			AddUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsEmailUniqueAsync(request.Email, cancellationToken);
		}

		public async Task ShouldHaveReceivedOneIsEmailUniqueAsync(
			UpdateUserCommand request,
			CancellationToken cancellationToken)
		{
			await repository.ShouldHaveReceivedOne().IsEmailUniqueAsync(request.Email, cancellationToken);
		}
	}
}
