namespace InstaConnect.Common.Infrastructure.Models.Options;

public class DatabaseOptions
{
    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
