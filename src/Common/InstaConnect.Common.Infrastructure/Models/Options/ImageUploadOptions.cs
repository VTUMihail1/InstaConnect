﻿namespace InstaConnect.Shared.Infrastructure.Models.Options;

internal class ImageUploadOptions
{
    [Required]
    public string CloudName { get; set; } = string.Empty;

    [Required]
    public string ApiKey { get; set; } = string.Empty;

    [Required]
    public string ApiSecret { get; set; } = string.Empty;
}
