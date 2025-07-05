using System.Net;

using CloudinaryDotNet;

using InstaConnect.Common.Abstractions;
using InstaConnect.Common.Exceptions;
using InstaConnect.Common.Exceptions.Base;
using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Infrastructure.Helpers;

internal class ImageHandler : IImageHandler
{
    private readonly Cloudinary _cloudinary;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IImageUploadFactory _imageUploadFactory;

    public ImageHandler(
        Cloudinary cloudinary,
        IApplicationMapper applicationMapper,
        IImageUploadFactory imageUploadFactory)
    {
        _cloudinary = cloudinary;
        _applicationMapper = applicationMapper;
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

        var uploadResult = _applicationMapper.Map<ImageResult>(imageUploadResult);

        return uploadResult;
    }
}
