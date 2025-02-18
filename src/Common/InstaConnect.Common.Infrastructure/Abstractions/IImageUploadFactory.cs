using CloudinaryDotNet.Actions;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Shared.Infrastructure.Abstractions;

public interface IImageUploadFactory
{
    ImageUploadParams GetImageUploadParams(IFormFile formFile);
}
