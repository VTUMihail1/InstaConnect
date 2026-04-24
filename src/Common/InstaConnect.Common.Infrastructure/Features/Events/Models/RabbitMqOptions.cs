using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Events.Models;

public class RabbitMqOptions : IApplicationOptions
{
    public const string SectionName = "RabbitMqConfiguration";

    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
