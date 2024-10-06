using Microsoft.AspNetCore.Http;

namespace InstaConnect.Shared.Business.Models;

public record ImageUploadModel(IFormFile FormFile);
