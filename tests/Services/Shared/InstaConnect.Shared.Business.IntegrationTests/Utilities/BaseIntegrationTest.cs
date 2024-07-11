using Bogus;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace InstaConnect.Shared.Business.UnitTests.Utilities;

public class BaseIntegrationTest
{
    protected Faker Faker { get; }

    protected CancellationToken CancellationToken { get; }

    public BaseIntegrationTest()
    {
        Faker = new Faker();
        CancellationToken = new CancellationToken();
    }
}
