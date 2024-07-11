using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InstaConnect.Shared.Data.Models.Options;

public class TokenOptions
{
    [Required]
    public string Issuer { get; set; } = string.Empty;

    [Required]
    public string Audience { get; set; } = string.Empty;

    [Required]
    public string AccessTokenSecurityKey { get; set; } = string.Empty;

    public byte[] AccessTokenSecurityKeyByteArray => Encoding.UTF8.GetBytes(AccessTokenSecurityKey);

    [Required]
    public int AccessTokenLifetimeSeconds { get; set; } = 0;

    [Required]
    public string AccountTokenSecurityKey { get; set; } = string.Empty;

    [Required]
    public int AccountTokenLifetimeSeconds { get; set; } = 0;

    public byte[] AccountTokenSecurityKeyByteArray => Encoding.UTF8.GetBytes(AccountTokenSecurityKey);
}
