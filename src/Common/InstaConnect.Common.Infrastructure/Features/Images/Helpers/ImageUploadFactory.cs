using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

using InstaConnect.Common.Infrastructure.Features.Images.Abstractions;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Infrastructure.Features.Images.Helpers;

internal class ImageUploadFactory : IImageUploadFactory
{
	public ImageUploadParams GetImageUploadParams(IFormFile formFile)
	{
		return new ImageUploadParams()
		{
			File = new FileDescription(formFile.FileName, formFile.OpenReadStream())
		};
	}
}
