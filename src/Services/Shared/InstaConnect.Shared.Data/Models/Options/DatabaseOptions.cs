using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Shared.Data.Models.Options;

public class DatabaseOptions
{
    [Required]
    public string ConnectionString { get; set; }
}
