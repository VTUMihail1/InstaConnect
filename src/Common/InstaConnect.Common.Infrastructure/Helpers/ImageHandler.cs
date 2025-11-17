using System.Net;

using CloudinaryDotNet;

using InstaConnect.Common.Domain.Abstractions;
using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Common.Infrastructure.Abstractions;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Infrastructure.Helpers;

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

        if (imageUploadResult.StatusCode != HttpStatusCode.OK)
        {
            throw new BadRequestException(imageUploadResult.Error.Message);
        }

        return new(imageUploadResult.Url.AbsolutePath);
    }
}
