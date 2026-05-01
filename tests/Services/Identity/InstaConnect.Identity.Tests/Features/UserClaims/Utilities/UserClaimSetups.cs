using InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.UserClaims.Utilities;

public static class UserClaimSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IUserClaimCommandRepository GetUserClaimCommandRepository()
		{
			return serviceProvider.GetRequiredService<IUserClaimCommandRepository>();
		}

		public IUserClaimIncludeBuilderFactory GetUserClaimIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IUserClaimIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IUserClaimCommandRepository GetUserClaimCommandRepository()
		{
			return serviceScope.ServiceProvider.GetUserClaimCommandRepository();
		}

		public IUserClaimIncludeBuilderFactory GetUserClaimIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetUserClaimIncludeBuilderFactory();
		}

		public async Task<UserClaim?> GetUserClaimByIdAsync(
			UserClaimId id,
			CancellationToken cancellationToken)
		{
			var claimInclude = serviceScope.GetUserClaimIncludeBuilderFactory().Create().WithUser().Build();

			return await serviceScope.GetUserClaimCommandRepository().GetByIdAsync(id, claimInclude, cancellationToken);
		}

		public async Task AddUserClaimAsync(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserClaimCommandRepository().AddAsync(userClaim, cancellationToken);
		}

		public async Task AddUserClaimRangeAsync(
			IEnumerable<UserClaim> userClaims,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserClaimCommandRepository().AddRangeAsync(userClaims, cancellationToken);
		}

		public async Task DeleteUserClaimAsync(
			UserClaim userClaim,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetUserClaimCommandRepository().DeleteAsync(userClaim, cancellationToken);
		}
	}
}
