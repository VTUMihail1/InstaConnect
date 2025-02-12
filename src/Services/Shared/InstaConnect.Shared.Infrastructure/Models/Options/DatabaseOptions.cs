using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Shared.Infrastructure.Models.Options;

public class DatabaseOptions
{
    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
