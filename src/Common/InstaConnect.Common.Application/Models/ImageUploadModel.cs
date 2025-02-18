using Microsoft.AspNetCore.Http;

namespace InstaConnect.Shared.Application.Models;

public record ImageUploadModel(IFormFile FormFile);
