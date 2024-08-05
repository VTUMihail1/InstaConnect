using Bogus;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Utilities;
using InstaConnect.Shared.Data.Models.Enums;
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

    protected Faker Faker { get; }

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

        Faker = new Faker();
        ServiceScope = serviceScope;
        CancellationToken = new CancellationToken();
        InstaConnectSender = ServiceScope.ServiceProvider.GetRequiredService<IInstaConnectSender>();
    }

    protected string GetAverageString(int maxLength, int minLength)
    {
        var result = Faker.Random.AlphaNumeric(GetAverageNumber(maxLength, minLength));

        return result;
    }

    protected int GetAverageNumber(int maxLength, int minLength)
    {
        var result = (maxLength + minLength) / 2;

        return result;
    }

    protected string GetHalfStartString(string value)
    {
        var result = value.Substring(0, value.Length / 2);

        return result;
    }

    protected string GetNonCaseMatchingString(string value)
    {
        var result = value.ToUpper();

        return result;
    }
}
