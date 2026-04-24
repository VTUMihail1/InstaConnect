using CloudinaryDotNet;

using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Common.Domain.Features.ValueObjects.Models;
using InstaConnect.Common.Infrastructure.Features.Images.Abstractions;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Infrastructure.Features.Images.Helpers;

internal class ImageHandler : IImageHandler
{
    private readonly Cloudinary _cloudinary;
    private readonly IImageUploadFactory _imageUploadFactory;

    public ImageHandler(
        Cloudinary cloudinary,
        IImageUploadFactory imageUploadFactory)
    {
        _cloudinary = cloudinary;
        _imageUploadFactory = imageUploadFactory;
    }

    public async Task<Image> UploadAsync(IFormFile formFile, CancellationToken cancellationToken)
    {
        var imageUploadParams = _imageUploadFactory.GetImageUploadParams(formFile);
        var imageUploadResult = await _cloudinary.UploadAsync(imageUploadParams, cancellationToken);

        return new(imageUploadResult.Url.AbsoluteUri);
    }
}
