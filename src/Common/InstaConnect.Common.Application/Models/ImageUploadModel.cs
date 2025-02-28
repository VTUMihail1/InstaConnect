using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Application.Models;

public record ImageUploadModel(IFormFile FormFile);
