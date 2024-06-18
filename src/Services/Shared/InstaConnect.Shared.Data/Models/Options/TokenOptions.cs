using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Users.Data.Models.Options;

public class TokenOptions
{
    [Required]
    public string Issuer { get; set; }

    [Required]
    public string Audience { get; set; }

    [Required]
    public string AccessTokenSecurityKey { get; set; }

    [Required]
    public int AccessTokenLifetimeSeconds { get; set; }

    [Required]
    public string AccountTokenSecurityKey { get; set; }

    [Required]
    public int AccountTokenLifetimeSeconds { get; set; }
}
