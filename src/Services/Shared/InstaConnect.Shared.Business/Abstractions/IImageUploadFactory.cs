﻿using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Shared.Business.Abstractions;

public interface IImageUploadFactory
{
    ImageUploadParams GetImageUploadParams(IFormFile formFile);
}
