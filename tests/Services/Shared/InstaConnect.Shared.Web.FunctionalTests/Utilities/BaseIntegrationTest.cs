using Bogus;

namespace InstaConnect.Shared.Web.FunctionalTests.Utilities;

public class BaseFunctionalTest
{
    protected Faker Faker { get; }

    protected CancellationToken CancellationToken { get; }

    public BaseFunctionalTest()
    {
        Faker = new Faker();
        CancellationToken = new CancellationToken();
    }
}
