using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using InstaConnect.Shared.Business.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Shared.Business.Helpers;

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
