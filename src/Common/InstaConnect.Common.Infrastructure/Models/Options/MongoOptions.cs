using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Infrastructure.Models.Options;

public class MongoOptions : IApplicationOptions
{
    public const string SectionName = "MongoConfiguration";

    [Required]
    public string ConnectionString { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;
}
