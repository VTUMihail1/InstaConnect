using CloudinaryDotNet.Actions;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Infrastructure.Features.Images.Abstractions;

public interface IImageUploadFactory
{
    ImageUploadParams GetImageUploadParams(IFormFile formFile);
}
