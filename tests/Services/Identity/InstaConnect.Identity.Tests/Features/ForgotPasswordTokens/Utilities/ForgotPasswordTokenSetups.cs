using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Identity.Tests.Features.ForgotPasswordTokens.Utilities;

public static class ForgotPasswordTokenSetups
{
	extension(IServiceProvider serviceProvider)
	{
		public IForgotPasswordTokenCommandRepository GetForgotPasswordTokenCommandRepository()
		{
			return serviceProvider.GetRequiredService<IForgotPasswordTokenCommandRepository>();
		}

		public IForgotPasswordTokenIncludeBuilderFactory GetForgotPasswordTokenIncludeBuilderFactory()
		{
			return serviceProvider.GetRequiredService<IForgotPasswordTokenIncludeBuilderFactory>();
		}
	}

	extension(IServiceScope serviceScope)
	{
		public IForgotPasswordTokenCommandRepository GetForgotPasswordTokenCommandRepository()
		{
			return serviceScope.ServiceProvider.GetForgotPasswordTokenCommandRepository();
		}

		public IForgotPasswordTokenIncludeBuilderFactory GetForgotPasswordTokenIncludeBuilderFactory()
		{
			return serviceScope.ServiceProvider.GetForgotPasswordTokenIncludeBuilderFactory();
		}

		public async Task<ForgotPasswordToken?> GetByIdAsync(
			ForgotPasswordTokenId id,
			CancellationToken cancellationToken)
		{
			var include = serviceScope.GetForgotPasswordTokenIncludeBuilderFactory().Create().WithUser().Build();

			return (await serviceScope.GetForgotPasswordTokenCommandRepository().GetByIdAsync(id, include, cancellationToken)).SetUser();
		}

		public async Task AddAsync(
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetForgotPasswordTokenCommandRepository().AddAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task AddRangeAsync(
			IEnumerable<ForgotPasswordToken> forgotPasswordTokens,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetForgotPasswordTokenCommandRepository().AddRangeAsync(forgotPasswordTokens, cancellationToken);
		}

		public async Task UpdateAsync(
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetForgotPasswordTokenCommandRepository().UpdateAsync(forgotPasswordToken, cancellationToken);
		}

		public async Task DeleteAsync(
			ForgotPasswordToken forgotPasswordToken,
			CancellationToken cancellationToken)
		{
			await serviceScope.GetForgotPasswordTokenCommandRepository().DeleteAsync(forgotPasswordToken, cancellationToken);
		}
	}
}
