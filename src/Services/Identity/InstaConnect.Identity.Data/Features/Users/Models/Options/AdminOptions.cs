﻿using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Identity.Data.Features.Users.Models.Options;

internal class AdminOptions
{
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
