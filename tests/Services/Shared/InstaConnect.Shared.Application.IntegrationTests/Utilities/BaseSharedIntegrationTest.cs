﻿using InstaConnect.Shared.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Shared.Application.IntegrationTests.Utilities;

public class BaseSharedIntegrationTest
{
    protected IServiceScope ServiceScope { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    public BaseSharedIntegrationTest(
        IServiceScope serviceScope)
    {
        ServiceScope = serviceScope;
        CancellationToken = new CancellationToken();
        InstaConnectSender = ServiceScope.ServiceProvider.GetRequiredService<IInstaConnectSender>();
    }
}
