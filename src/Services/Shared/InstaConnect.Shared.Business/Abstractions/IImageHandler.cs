using CloudinaryDotNet.Actions;
using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Shared.Business.Abstractions;

public interface IImageHandler
{
    Task<ImageUploadResult> UploadAsync(ImageUploadModel imageUploadModel, CancellationToken cancellationToken);
}
