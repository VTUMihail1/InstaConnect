using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Infrastructure.Models.Options;

public class DatabaseOptions
{
    public const string SectionName = "DatabaseConfiguration";

    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
