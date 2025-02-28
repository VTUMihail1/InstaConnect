using InstaConnect.Common.Application.Models;

namespace InstaConnect.Common.Application.Abstractions;

public interface IImageHandler
{
    Task<ImageResult> UploadAsync(ImageUploadModel imageUploadModel, CancellationToken cancellationToken);
}
