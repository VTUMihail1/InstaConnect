using System.Net;

using CloudinaryDotNet;

using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Application.Models;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Infrastructure.Abstractions;

namespace InstaConnect.Shared.Infrastructure.Helpers;

internal class ImageHandler : IImageHandler
{
    private readonly Cloudinary _cloudinary;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IImageUploadFactory _imageUploadFactory;

    public ImageHandler(
        Cloudinary cloudinary,
        IInstaConnectMapper instaConnectMapper,
        IImageUploadFactory imageUploadFactory)
    {
        _cloudinary = cloudinary;
        _instaConnectMapper = instaConnectMapper;
        _imageUploadFactory = imageUploadFactory;
    }

    public async Task<ImageResult> UploadAsync(ImageUploadModel imageUploadModel, CancellationToken cancellationToken)
    {
        var imageUploadParams = _imageUploadFactory.GetImageUploadParams(imageUploadModel.FormFile);
        var imageUploadResult = await _cloudinary.UploadAsync(imageUploadParams, cancellationToken);

        if (imageUploadResult.StatusCode != HttpStatusCode.OK)
        {
            throw new BadRequestException(imageUploadResult.Error.Message);
        }

        var uploadResult = _instaConnectMapper.Map<ImageResult>(imageUploadResult);

        return uploadResult;
    }
}
