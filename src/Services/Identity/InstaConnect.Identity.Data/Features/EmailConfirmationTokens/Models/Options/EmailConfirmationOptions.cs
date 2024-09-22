using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Options;

public class EmailConfirmationOptions
{
    [Required]
    public int LifetimeSeconds { get; set; } = 0;
}
