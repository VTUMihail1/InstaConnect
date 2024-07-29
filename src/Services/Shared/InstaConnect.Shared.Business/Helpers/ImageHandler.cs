using System.Net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Models;

namespace InstaConnect.Shared.Business.Helpers;

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

    public async Task<ImageUploadResult> UploadAsync(ImageUploadModel imageUploadModel, CancellationToken cancellationToken)
    {
        var imageUploadParams = _imageUploadFactory.GetImageUploadParams(imageUploadModel.FormFile);
        var uploadResult = await _cloudinary.UploadAsync(imageUploadParams, cancellationToken);

        if (uploadResult.StatusCode != HttpStatusCode.OK)
        {
            throw new BadRequestException(uploadResult.Error.Message);
        }

        return uploadResult;
    }
}
