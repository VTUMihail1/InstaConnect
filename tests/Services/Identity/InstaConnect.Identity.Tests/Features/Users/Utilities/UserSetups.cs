using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Identity.Domain.Features.Users.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public static class UserSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserCommandRepository GetCommandRepository()
		{
			return serviceProvider.GetRequiredService<IUserCommandRepository>();
		}

		public IUserIncludeBuilderFactory GetIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IUserIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserCommandRepository GetCommandRepository()
		{
			return serviceScope.ServiceProvider.GetCommandRepository();
		}

		public IUserIncludeBuilderFactory GetIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetIncludeBuilderFactory();
		}

		public async Task<User?> GetByIdAsync(
			UserId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetIncludeBuilderFactory().Create().WithUserClaims().WithRefreshTokens().WithForgotPasswordTokens().WithEmailConfirmationTokens().Build();

			return (await serviceScope.GetCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetUserClaims().SetRefreshTokens().SetForgotPasswordTokens().SetEmailConfirmationTokens();
		}

		public async Task AddAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().AddAsync(user, cancellationToken);
		}

		public async Task UpdateAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().UpdateAsync(user, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<User> users,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().AddRangeAsync(users, cancellationToken);
		}

		public async Task DeleteAsync(
			User user,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetCommandRepository().DeleteAsync(user, cancellationToken);
		}
	}
}
