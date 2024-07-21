using Bogus;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Shared.Web.UnitTests.Utilities;

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
