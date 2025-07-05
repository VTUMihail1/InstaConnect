namespace InstaConnect.Common.Infrastructure.Extensions;
public static class BusRegistrationConfiguratorExtensions
{
    public static void AddTransactionalOutbox<TContext>(this IBusRegistrationConfigurator busRegistrationConfigurator)
        where TContext : DbContext
    {
        busRegistrationConfigurator.AddEntityFrameworkOutbox<TContext>(outbox =>
        {
            outbox.QueryDelay = TimeSpan.FromSeconds(1);

            outbox.UsePostgres();
            outbox.UseBusOutbox();
        });
    }
}
