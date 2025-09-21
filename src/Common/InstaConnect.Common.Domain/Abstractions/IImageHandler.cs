using InstaConnect.Common.Application.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Application.Abstractions;

public interface IImageHandler
{
    Task<string> UploadAsync(IFormFile formFile, CancellationToken cancellationToken);
}
