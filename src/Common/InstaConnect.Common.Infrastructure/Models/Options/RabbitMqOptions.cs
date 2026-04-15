using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Common.Infrastructure.Models.Options;

public class RabbitMqOptions : IApplicationOptions
{
    public const string SectionName = "RabbitMqConfiguration";

    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
