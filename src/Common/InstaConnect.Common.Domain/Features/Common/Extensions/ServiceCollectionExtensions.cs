using System.Reflection;

using FluentValidation;

using InstaConnect.Common.Domain.Features.Common.Abstractions;
using InstaConnect.Common.Domain.Features.Common.Helpers;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

using Scrutor;

namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddServicesWithMatchingInterfaces(params Assembly[] assemblies)
		{
			return serviceCollection.AddServicesWithMatchingInterfaces(_ => true, assemblies);
		}

		public IServiceCollection AddServicesWithMatchingInterfaces(Func<Type, bool> predicate, params Assembly[] assemblies)
		{
			serviceCollection
				.Scan(selector => selector
					.FromAssemblies(assemblies)
					.AddClasses(classes => classes.Where(predicate), false)
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

		public IServiceCollection AddValidatedOptions<TOptions, TValidator>(string sectionName)
			where TOptions : class, IApplicationOptions
			where TValidator : IValidator<TOptions>, new()
		{
			serviceCollection
				.AddOptions<TOptions>()
				.ValidateOnStart();

			serviceCollection.TryAddTransient<IOptionsFactory<TOptions>>(serviceProvider => new ConfigurationOptionsFactory<TOptions>(
				serviceProvider.GetRequiredService<IConfiguration>(),
				sectionName,
				serviceProvider.GetServices<IConfigureOptions<TOptions>>(),
				serviceProvider.GetServices<IPostConfigureOptions<TOptions>>(),
				serviceProvider.GetServices<IValidateOptions<TOptions>>()));

			serviceCollection.TryAddEnumerable(ServiceDescriptor.Singleton<IValidateOptions<TOptions>>(
				new FluentValidationOptionsValidator<TOptions>(new TValidator())));

			return serviceCollection;
		}
	}
}
