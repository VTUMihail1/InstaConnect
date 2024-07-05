using Microsoft.AspNetCore.Http;

namespace InstaConnect.Shared.Business.Models;
public class ImageUploadModel
{
    public IFormFile FormFile { get; set; }
}
