using Bogus;
using InstaConnect.Messages.Business.Utilities;
using InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Shared.Data.Models.Enums;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Shared.Business.UnitTests.Utilities;

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

        ValidPageValue = GetAverageNumber(SharedBusinessConfigurations.PAGE_MAX_VALUE, SharedBusinessConfigurations.PAGE_MIN_VALUE);
        ValidPageSizeValue = GetAverageNumber(SharedBusinessConfigurations.PAGE_SIZE_MAX_VALUE, SharedBusinessConfigurations.PAGE_SIZE_MIN_VALUE);

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
}
