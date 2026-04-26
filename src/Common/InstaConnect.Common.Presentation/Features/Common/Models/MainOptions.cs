using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Presentation.Features.Common.Models;

public class MainOptions : IApplicationOptions
{
    public const string SectionName = "MainConfiguration";

    public string BaseUrl { get; set; } = string.Empty;
}
