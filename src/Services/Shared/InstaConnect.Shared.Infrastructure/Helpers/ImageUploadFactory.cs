using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using InstaConnect.Shared.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Shared.Infrastructure.Helpers;

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
