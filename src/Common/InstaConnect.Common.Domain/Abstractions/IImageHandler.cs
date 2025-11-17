using InstaConnect.Common.Domain.Models.ValueObjects;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Domain.Abstractions;

public interface IImageHandler
{
    Task<Image> UploadAsync(IFormFile formFile, CancellationToken cancellationToken);
}
