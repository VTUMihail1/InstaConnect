using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Identity.Infrastructure.Features.Common.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

internal static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		internal IServiceCollection AddForgotPasswordTokenServices()
		{
			serviceCollection.AddValidatedOptions<ForgotPasswordTokenOptions>(ForgotPasswordTokenOptions.SectionName);

			serviceCollection.AddImplementationsOf<IForgotPasswordTokenIncluder>(IdentityInfrastructureReference.Assembly);

			BsonClassMap.TryRegisterClassMap<ForgotPasswordToken>(cm =>
			{
				cm.MapIdMember(c => c.Id);

				cm.MapMember(c => c.Id);
				cm.MapMember(c => c.ExpiresAtUtc);
				cm.MapMember(c => c.CreatedAtUtc);

				cm.MapMemberWithoutSerialization(c => c.User);

				cm.MapCreator(c => new ForgotPasswordToken(
					c.Id,
					c.ExpiresAtUtc,
					c.CreatedAtUtc));

				cm.SetIgnoreExtraElements(true);
			});

			return serviceCollection;
		}
	}
}
