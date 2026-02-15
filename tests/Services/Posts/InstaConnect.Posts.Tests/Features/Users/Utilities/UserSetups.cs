using InstaConnect.Common.Tests.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Abstractions;
using InstaConnect.Posts.Domain.Features.Users.Models.ValueObjects;
using InstaConnect.Posts.Infrastructure.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace InstaConnect.Posts.Tests.Features.Users.Utilities;
public static class UserSetups
{
    public static IUserCommandRepository GetUserCommandRepository(this IServiceScope serviceScope)
    {
        return serviceScope.ServiceProvider.GetRequiredService<IUserCommandRepository>();
    }

    public static IUserIncludeBuilderFactory GetUserIncludeBuilderFactory(this IServiceScope serviceScope)
    {
        return serviceScope.ServiceProvider.GetRequiredService<IUserIncludeBuilderFactory>();
    }

    public static async Task<User?> GetUserByIdAsync(
        this IServiceScope serviceScope,
        UserId id,
        CancellationToken cancellationToken)
    {
        return await serviceScope.GetUserCommandRepository().GetByIdAsync(id, cancellationToken);
    }

    public static async Task AddUserAsync(
        this IServiceScope serviceScope,
        User user,
        CancellationToken cancellationToken)
    {
        var userRepository = serviceScope.GetUserCommandRepository();

        await userRepository.AddAsync(user, cancellationToken);
    }

    public static async Task AddUserRangeAsync(
        this IServiceScope serviceScope,
        IEnumerable<User> users,
        CancellationToken cancellationToken)
    {
        var userRepository = serviceScope.GetUserCommandRepository();

        await userRepository.AddRangeAsync(users, cancellationToken);
    }

    public static async Task DeleteUserAsync(
        this IServiceScope serviceScope,
        User user,
        CancellationToken cancellationToken)
    {
        var userRepository = serviceScope.GetUserCommandRepository();

        await userRepository.DeleteAsync(user, cancellationToken);
    }

    public static async Task ResetUserDatabase(
        this IServiceScope serviceScope,
        CancellationToken cancellationToken)
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<IPostsContext>();

        await context.Users.ResetAsync(cancellationToken);
    }
}
