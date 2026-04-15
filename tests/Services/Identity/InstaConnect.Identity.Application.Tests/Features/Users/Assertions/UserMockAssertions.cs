using InstaConnect.Identity.Application.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.Users.Assertions;

public static class UserMockAssertions
{
    extension(IUserQueryService userService)
    {
        public async Task ShouldReceiveOneGetAllAsync(
        GetAllUsersQueryRequest request,
        CancellationToken cancellationToken)
        {
            await userService.ShouldHaveReceivedOne().GetAllAsync(UserMatcher.IsGetAllUsersQuery(request), cancellationToken);
        }

        public async Task ShouldReceiveOneGetByIdAsync(
            GetUserByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await userService.ShouldHaveReceivedOne().GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken);
        }

        public async Task ShouldReceiveOneGetByIdAsync(
            GetCurrentUserByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await userService.ShouldHaveReceivedOne().GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken);
        }

        public async Task ShouldReceiveOneGetByIdAsync(
            GetUserDetailsByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await userService.ShouldHaveReceivedOne().GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken);
        }

        public async Task ShouldReceiveOneGetByIdAsync(
            GetCurrentUserDetailsByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            await userService.ShouldHaveReceivedOne().GetByIdAsync(UserMatcher.IsGetUserByIdQuery(request), cancellationToken);
        }
    }

    extension(IUserCommandService userService)
    {
        public async Task ShouldReceiveOneAddAsync(
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
        {
            await userService.ShouldHaveReceivedOne().AddAsync(UserMatcher.IsAddUserCommand(request), cancellationToken);
        }

        public async Task ShouldReceiveOneUpdateAsync(
            UpdateCurrentUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await userService.ShouldHaveReceivedOne().UpdateAsync(UserMatcher.IsUpdateUserCommand(request), cancellationToken);
        }

        public async Task ShouldReceiveOneDeleteAsync(
            DeleteUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await userService.ShouldHaveReceivedOne().DeleteAsync(UserMatcher.IsDeleteUserCommand(request), cancellationToken);
        }

        public async Task ShouldReceiveOneDeleteAsync(
            DeleteCurrentUserCommandRequest request,
            CancellationToken cancellationToken)
        {
            await userService.ShouldHaveReceivedOne().DeleteAsync(UserMatcher.IsDeleteUserCommand(request), cancellationToken);
        }
    }
}
