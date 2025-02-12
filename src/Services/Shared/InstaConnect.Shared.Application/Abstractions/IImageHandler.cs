using InstaConnect.Shared.Application.Models;

namespace InstaConnect.Shared.Application.Abstractions;

public interface IImageHandler
{
    Task<ImageResult> UploadAsync(ImageUploadModel imageUploadModel, CancellationToken cancellationToken);
}
