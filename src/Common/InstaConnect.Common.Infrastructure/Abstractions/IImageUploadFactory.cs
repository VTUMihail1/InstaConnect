using CloudinaryDotNet.Actions;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IImageUploadFactory
{
    ImageUploadParams GetImageUploadParams(IFormFile formFile);
}
