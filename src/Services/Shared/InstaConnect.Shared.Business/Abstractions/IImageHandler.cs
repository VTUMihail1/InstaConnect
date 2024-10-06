using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Shared.Business.Abstractions;

public interface IImageHandler
{
    Task<ImageResult> UploadAsync(ImageUploadModel imageUploadModel, CancellationToken cancellationToken);
}
