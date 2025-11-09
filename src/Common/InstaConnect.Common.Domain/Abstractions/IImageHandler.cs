using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Domain.Abstractions;

public interface IImageHandler
{
    Task<string> UploadAsync(IFormFile formFile, CancellationToken cancellationToken);
}
