using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Infrastructure.Models.Options;

public class CloudinaryOptions : IApplicationOptions
{
    public const string SectionName = "CloudinaryConfiguration";

    [Required]
    public string CloudName { get; set; } = string.Empty;

    [Required]
    public string ApiKey { get; set; } = string.Empty;

    [Required]
    public string ApiSecret { get; set; } = string.Empty;
}
