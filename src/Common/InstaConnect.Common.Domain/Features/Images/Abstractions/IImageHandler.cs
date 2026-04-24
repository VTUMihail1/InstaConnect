using InstaConnect.Common.Domain.Features.ValueObjects.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Domain.Features.Images.Abstractions;

public interface IImageHandler
{
    Task<Image> UploadAsync(IFormFile formFile, CancellationToken cancellationToken);
}
