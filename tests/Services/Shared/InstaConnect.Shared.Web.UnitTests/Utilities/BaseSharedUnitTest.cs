using Bogus;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Web.Abstractions;

namespace InstaConnect.Shared.Web.UnitTests.Utilities;

public class BaseSharedUnitTest
{
    protected readonly int ValidPageValue;
    protected readonly int ValidPageSizeValue;
    protected readonly int ValidTotalCountValue;

    protected readonly string ValidSortPropertyName;
    protected readonly string InvalidSortPropertyName;

    protected readonly SortOrder ValidSortOrderProperty;

    protected Faker Faker { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectSender InstaConnectSender { get; }

    protected ICurrentUserContext CurrentUserContext { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    public BaseSharedUnitTest(
        IInstaConnectSender instaConnectSender,
        ICurrentUserContext currentUserContext,
        IInstaConnectMapper instaConnectMapper)
    {
        ValidPageValue = 1;
        ValidPageSizeValue = 20;
        ValidTotalCountValue = 1;

        ValidSortPropertyName = "CreatedAt";
        InvalidSortPropertyName = "CreatedAtt";

        ValidSortOrderProperty = SortOrder.ASC;

        Faker = new Faker();
        CancellationToken = new CancellationToken();
        InstaConnectSender = instaConnectSender;
        CurrentUserContext = currentUserContext;
        InstaConnectMapper = instaConnectMapper;
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
