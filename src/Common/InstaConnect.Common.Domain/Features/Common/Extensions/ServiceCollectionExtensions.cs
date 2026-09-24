using System.Reflection;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Scrutor;

namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddServicesWithMatchingInterfaces(params Assembly[] assemblies)
		{
			serviceCollection
				.Scan(selector => selector
					.FromAssemblies(assemblies)
					.AddClasses(false)
					.UsingRegistrationStrategy(RegistrationStrategy.Skip)
					.AsMatchingInterface()
					.WithScopedLifetime());

			return serviceCollection;
		}

		public IServiceCollection AddImplementationsOf<TInterface>(Assembly assembly)
			where TInterface : class
		{
			var implementations = assembly
				.DefinedTypes
				.Where(type => type is { IsAbstract: false, IsInterface: false } &&
							   type.IsAssignableTo(typeof(TInterface)))
				.Select(type => ServiceDescriptor.Transient(typeof(TInterface), type))
				.ToArray();

			serviceCollection.TryAddEnumerable(implementations);

			return serviceCollection;
		}

		public IServiceCollection AddValidatedOptions<TOptions>(string sectionName)
			where TOptions : class, IApplicationOptions
		{
			serviceCollection
				.AddOptions<TOptions>()
				.BindConfiguration(sectionName)
				.ValidateDataAnnotations()
				.ValidateOnStart();

			return serviceCollection;
		}
	}
}
