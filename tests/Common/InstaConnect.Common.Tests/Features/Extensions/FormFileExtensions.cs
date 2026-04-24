using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Tests.Features.Extensions;

public static class FormFileExtensions
{
    extension(IFormFile formFile)
    {
        public string GetUrl()
        {
            const string Format = "https://{0}-image.com";

            return Format.FormatCurrentCulture(Uri.EscapeDataString(formFile.FileName));
        }
    }
}
