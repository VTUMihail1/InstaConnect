using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Common.Infrastructure.Models.Options;

internal class ImageUploadOptions
{
    public const string SectionName = "ImageUploadConfiguration";

    [Required]
    public string CloudName { get; set; } = string.Empty;

    [Required]
    public string ApiKey { get; set; } = string.Empty;

    [Required]
    public string ApiSecret { get; set; } = string.Empty;
}
