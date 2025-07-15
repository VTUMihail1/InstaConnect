using System.Threading;

using InstaConnect.Common.Application.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Utilities;

public static class Setups
{
    public static IApplicationSender GetApplicationSender(this IServiceScope serviceScope)
    {
        var applicationSender = serviceScope.ServiceProvider.GetRequiredService<IApplicationSender>();

        return applicationSender;
    }

    public static IUnitOfWork GetUnitOfWork(this IServiceScope serviceScope)
    {
        var unitOfWork = serviceScope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        return unitOfWork;
    }
}
