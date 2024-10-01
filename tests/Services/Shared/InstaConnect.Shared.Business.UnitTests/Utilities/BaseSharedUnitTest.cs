using Bogus;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Shared.Business.UnitTests.Utilities;

public class BaseSharedUnitTest
{
    protected readonly int ValidPageValue;
    protected readonly int ValidPageSizeValue;
    protected readonly int ValidTotalCountValue;

    protected readonly string ValidSortPropertyName;
    protected readonly string InvalidSortPropertyName;

    protected readonly SortOrder ValidSortOrderProperty;

    protected IUnitOfWork UnitOfWork { get; }

    protected CancellationToken CancellationToken { get; }

    protected IInstaConnectMapper InstaConnectMapper { get; }

    protected IEntityPropertyValidator EntityPropertyValidator { get; }

    public BaseSharedUnitTest(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IEntityPropertyValidator entityPropertyValidator)
    {
        ValidPageValue = 1;
        ValidPageSizeValue = 20;
        ValidTotalCountValue = 1;

        ValidSortPropertyName = "CreatedAt";
        InvalidSortPropertyName = "CreatedAtt";

        ValidSortOrderProperty = SortOrder.ASC;

        UnitOfWork = unitOfWork;
        InstaConnectMapper = instaConnectMapper;
        CancellationToken = new CancellationToken();
        EntityPropertyValidator = entityPropertyValidator;
    }
}
