using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedAddedAsync(
            EmailConfirmationToken entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenAddedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedAddedAsync(
            ICollection<EmailConfirmationToken> entities,
            CancellationToken cancellationToken)
        {
            foreach (var entity in entities)
            {
                await eventHarness.ShouldHavePublishedAddedAsync(entity, cancellationToken);
            }
        }

        public async Task ShouldHavePublishedDeletedAsync(
            EmailConfirmationToken entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenDeletedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHavePublishedDeletedAsync(
            ICollection<EmailConfirmationToken> entities,
            CancellationToken cancellationToken)
        {
            foreach (var entity in entities)
            {
                await eventHarness.ShouldHavePublishedDeletedAsync(entity, cancellationToken);
            }
        }

        public async Task ShouldHaveNotPublishedDeletedAsync(
            EmailConfirmationToken entity,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHaveNotPublishedAsync<EmailConfirmationTokenDeletedEventRequest>(
                p => p.Matches(entity),
                cancellationToken);
        }

        public async Task ShouldHaveNotPublishedDeletedAsync(
            ICollection<EmailConfirmationToken> entities,
            CancellationToken cancellationToken)
        {
            foreach (var entity in entities)
            {
                await eventHarness.ShouldHaveNotPublishedDeletedAsync(entity, cancellationToken);
            }
        }
    }
}
