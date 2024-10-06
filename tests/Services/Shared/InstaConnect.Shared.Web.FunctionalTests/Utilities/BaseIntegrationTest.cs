using System.Security.Claims;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Shared.Web.FunctionalTests.Utilities;

public class BaseSharedFunctionalTest
{
    protected readonly string ApiRoute;


    protected HttpClient HttpClient { get; }

    protected ITestHarness TestHarness
    {
        get
        {
            var serviceScope = ServiceScope.ServiceProvider.CreateScope();
            var testHarness = serviceScope.ServiceProvider.GetTestHarness();

            return testHarness;
        }
    }

    protected IServiceScope ServiceScope { get; }

    protected CancellationToken CancellationToken { get; }

    protected Dictionary<string, object> ValidJwtConfig { get; set; }

    public BaseSharedFunctionalTest(
        HttpClient httpClient,
        IServiceScope serviceScope,
        string apiRoute)
    {
        ApiRoute = apiRoute;

        HttpClient = httpClient;
        ServiceScope = serviceScope;
        CancellationToken = new CancellationToken();
        ValidJwtConfig = new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, string.Empty }
        };
    }

    protected string GetIdRoute(string id)
    {
        var route = $"{ApiRoute}/{id}";

        return route;
    }


}
