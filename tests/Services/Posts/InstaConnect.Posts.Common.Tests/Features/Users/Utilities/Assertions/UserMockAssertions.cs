using InstaConnect.Common.Application.Abstractions;
using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;
using InstaConnect.Users.Application.Features.Users.Commands.Add;
using InstaConnect.Users.Application.Features.Users.Commands.Delete;

using NSubstitute;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities.Assertions;

public static class UserMockAssertions
{
    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(UserMatcher.IsAddUserCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        UserUpdatedEventRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(UserMatcher.IsUpdateUserCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneSendAsync(
        this IApplicationSender applicationSender,
        UserDeletedEventRequest request,
        CancellationToken cancellationToken)
    {
        await applicationSender.Received(1).SendAsync(UserMatcher.IsDeleteUserCommand(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneAddAsync(
        this IUserService userService,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await userService.Received(1).AddAsync(UserMatcher.IsAddUserRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneUpdateAsync(
        this IUserService userService,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await userService.Received(1).UpdateAsync(UserMatcher.IsUpdateUserRequest(request), cancellationToken);
    }

    public static async Task ShouldReceiveOneDeleteAsync(
        this IUserService userService,
        DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await userService.Received(1).DeleteAsync(UserMatcher.IsDeleteUserRequest(request), cancellationToken);
    }
}
