using Bogus;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Common.Models.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Shared.Business.IntegrationTests.Utilities;

public class BaseSharedIntegrationTest
{
    protected readonly int ValidPageValue;
    protected readonly int ValidPageSizeValue;
    protected readonly int ValidTotalCountValue;

    protected readonly string ValidSortPropertyName;
    protected readonly string InvalidSortPropertyName;

    protected readonly SortOrder ValidSortOrderProperty;

    protected IServiceScope ServiceScope { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    public BaseSharedIntegrationTest(
        IServiceScope serviceScope)
    {
        ValidPageValue = 1;
        ValidPageSizeValue = 20;
        ValidTotalCountValue = 1;

        ValidSortPropertyName = "CreatedAt";
        InvalidSortPropertyName = "CreatedAtt";

        ValidSortOrderProperty = SortOrder.ASC;

        ServiceScope = serviceScope;
        CancellationToken = new CancellationToken();
        InstaConnectSender = ServiceScope.ServiceProvider.GetRequiredService<IInstaConnectSender>();
    }
}
