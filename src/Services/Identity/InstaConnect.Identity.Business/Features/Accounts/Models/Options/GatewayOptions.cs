using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Identity.Business.Features.Accounts.Models.Options;

public class GatewayOptions
{
    [Required]
    public string Url { get; set; } = string.Empty;
}
