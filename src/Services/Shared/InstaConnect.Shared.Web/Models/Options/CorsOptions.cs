using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Shared.Web.Models.Options;

public class CorsOptions
{
    [Required]
    public string AllowedOrigins { get; set; }
}
