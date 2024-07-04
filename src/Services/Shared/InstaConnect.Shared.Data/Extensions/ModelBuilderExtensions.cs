using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Shared.Data.Extensions;
public static class ModelBuilderExtensions
{
    public static void ApplyTransactionalOutboxEntityConfiguration(this ModelBuilder modelBuilder)
    {
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
    }
}
