namespace InstaConnect.Shared.Infrastructure.Extensions;
public static class BusRegistrationConfiguratorExtensions
{
    private const int QUERY_DELAY = 1;

    public static void AddTransactionalOutbox<TContext>(this IBusRegistrationConfigurator busRegistrationConfigurator)
        where TContext : DbContext
    {
        busRegistrationConfigurator.AddEntityFrameworkOutbox<TContext>(outbox =>
        {
            outbox.QueryDelay = TimeSpan.FromSeconds(QUERY_DELAY);

            outbox.UsePostgres();
            outbox.UseBusOutbox();
        });
    }
}
