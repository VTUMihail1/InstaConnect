using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InstaConnect.Common.Tests.Utilities.Events;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Common.Tests.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEventHarness(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMassTransitTestHarness();
        serviceCollection.AddScoped<IEventHarness, EventHarness>();

        return serviceCollection;
    }
}
