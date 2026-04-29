using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.Common.Extensions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Abstractions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Helpers;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Presentation.Features.ExceptionHandling.Extensions;

public static class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddExceptionHandler()
		{
			serviceCollection.AddSingleton<IApplicationProblemDetailsFactory, ApplicationProblemDetailsFactory>()
							 .AddSingleton<IApplicationProblemDetailsService, ApplicationProblemDetailsService>()
							 .AddImplementationsOf<IBaseExceptionStatus>(CommonPresentationReference.Assembly);

			serviceCollection.AddProblemDetails();

			serviceCollection.AddExceptionHandler<InvalidValidationExceptionHandler>()
							 .AddExceptionHandler<BaseExceptionHandler>()
							 .AddExceptionHandler<ExceptionHandler>();

			return serviceCollection;
		}
	}
}
