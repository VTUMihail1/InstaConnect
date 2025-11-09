using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Common.Infrastructure.Models.Options;

public class MongoDatabaseOptions
{
    public const string SectionName = "DatabaseConfiguration";

    [Required]
    public string ConnectionString { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;
}
