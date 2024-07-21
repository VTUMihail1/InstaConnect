using Bogus;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using NSubstitute;

namespace InstaConnect.Shared.Business.UnitTests.Utilities;

public class BaseUnitTest
{
    protected Faker Faker { get; }

    protected CancellationToken CancellationToken { get; }

    public BaseUnitTest()
    {
        Faker = new Faker();
        CancellationToken = new CancellationToken();
    }
}
