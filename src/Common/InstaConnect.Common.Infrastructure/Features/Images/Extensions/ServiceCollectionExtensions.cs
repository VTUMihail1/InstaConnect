using CloudinaryDotNet;

using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Images.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Images.Helpers;
using InstaConnect.Common.Infrastructure.Features.Images.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Infrastructure.Extensions;

public static partial class ServiceCollectionExtensions
{
	extension(IServiceCollection serviceCollection)
	{
		public IServiceCollection AddCloudinary(IConfiguration configuration)
		{
			serviceCollection.AddValidatedOptions<CloudinaryOptions>(CloudinaryOptions.SectionName);
			var options = configuration.GetOptions<CloudinaryOptions>(CloudinaryOptions.SectionName);

			serviceCollection.AddScoped(_ => new Cloudinary(new Account(
				options.CloudName,
				options.ApiKey,
				options.ApiSecret)));

			serviceCollection.AddScoped<IImageUploadFactory, ImageUploadFactory>()
							 .AddScoped<IImageHandler, ImageHandler>();

			return serviceCollection;
		}
	}
}
