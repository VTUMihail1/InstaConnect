﻿using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Models.Options;

public class EmailConfirmationOptions
{
    [Required]
    public int LifetimeSeconds { get; set; } = 0;

    [Required]
    public string UrlTemplate { get; set; } = string.Empty;
}
