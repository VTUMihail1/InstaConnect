using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Identity.Business.Features.Users.Models.Options;

public class GatewayOptions
{
    [Required]
    public string UrlTemplate { get; set; } = string.Empty;
}
