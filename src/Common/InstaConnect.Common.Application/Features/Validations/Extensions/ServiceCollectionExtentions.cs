using System.Reflection;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Application.Features.Validations.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddValidators(params Assembly[] assemblies)
		{
			ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

			serviceCollection.AddValidatorsFromAssemblies(assemblies);

			return serviceCollection;
		}
	}
}
