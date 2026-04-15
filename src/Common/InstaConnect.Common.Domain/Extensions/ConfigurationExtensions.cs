using InstaConnect.Common.Domain.Abstractions;

using Microsoft.Extensions.Configuration;

namespace InstaConnect.Common.Domain.Extensions;

public static class ConfigurationExtensions
{
    extension(IConfiguration configuration)
    {
        public TOptions GetOptions<TOptions>(string sectionName)
            where TOptions : class, IApplicationOptions
        {
            return configuration
                        .GetSection(sectionName)
                        .Get<TOptions>()!;
        }
    }
}
