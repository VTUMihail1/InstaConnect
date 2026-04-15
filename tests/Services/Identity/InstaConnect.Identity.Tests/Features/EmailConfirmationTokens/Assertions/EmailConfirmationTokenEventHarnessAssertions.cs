using InstaConnect.Identity.Events.Features.EmailConfirmationTokens;
using InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.EmailConfirmationTokens.Assertions;

public static class EmailConfirmationTokenEventHarnessAssertions
{
    extension(IEventHarness eventHarness)
    {
        public async Task ShouldHavePublishedEmailConfirmationTokenAddedAsync(
            EmailConfirmationToken emailConfirmationToken,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenAddedEventRequest>(
                p => p.Matches(emailConfirmationToken),
                cancellationToken);
        }

        public async Task ShouldHavePublishedEmailConfirmationTokenAddedRangeAsync(
            User user,
            CancellationToken cancellationToken)
        {
            foreach (var emailConfirmationToken in user.EmailConfirmationTokens.Select(a => a.AddUser(user)))
            {
                await eventHarness.ShouldHavePublishedEmailConfirmationTokenAddedAsync(emailConfirmationToken.AddUser(user), cancellationToken);
            }
        }

        public async Task ShouldHavePublishedEmailConfirmationTokenDeletedAsync(
            EmailConfirmationToken emailConfirmationToken,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHavePublishedAsync<EmailConfirmationTokenDeletedEventRequest>(
                p => p.Matches(emailConfirmationToken),
                cancellationToken);
        }

        public async Task ShouldHavePublishedEmailConfirmationTokenDeletedRangeAsync(
            User user,
            CancellationToken cancellationToken)
        {
            foreach (var emailConfirmationToken in user.EmailConfirmationTokens.Select(a => a.AddUser(user)))
            {
                await eventHarness.ShouldHavePublishedEmailConfirmationTokenDeletedAsync(emailConfirmationToken.AddUser(user), cancellationToken);
            }
        }

        public async Task ShouldHaveNotPublishedEmailConfirmationTokenDeletedAsync(
            EmailConfirmationToken emailConfirmationToken,
            CancellationToken cancellationToken)
        {
            await eventHarness.ShouldHaveNotPublishedAsync<EmailConfirmationTokenDeletedEventRequest>(
                p => p.Matches(emailConfirmationToken),
                cancellationToken);
        }

        public async Task ShouldHaveNotPublishedEmailConfirmationTokenDeletedRangeAsync(
            User user,
            CancellationToken cancellationToken)
        {
            foreach (var emailConfirmationToken in user.EmailConfirmationTokens.Select(a => a.AddUser(user)))
            {
                await eventHarness.ShouldHaveNotPublishedEmailConfirmationTokenDeletedAsync(emailConfirmationToken, cancellationToken);
            }
        }
    }
}
