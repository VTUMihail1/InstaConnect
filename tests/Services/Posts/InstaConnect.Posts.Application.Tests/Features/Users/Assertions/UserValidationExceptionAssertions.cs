using InstaConnect.Common.Application.Abstractions;

namespace InstaConnect.Posts.Application.Tests.Features.Users.Assertions;

public static class UserValidationExceptionAssertions
{
    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateUserCommandRequest, string, UpdateUserCommandResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForIdAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync(
            p => p.Id,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForNameAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateUserCommandRequest, string, UpdateUserCommandResponse>(
            p => p.Name,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForNameAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
            p => p.Name,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForFirstNameAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateUserCommandRequest, string, UpdateUserCommandResponse>(
            p => p.FirstName,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForFirstNameAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
            p => p.FirstName,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForLastNameAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateUserCommandRequest, string, UpdateUserCommandResponse>(
            p => p.LastName,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForLastNameAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
            p => p.LastName,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForEmailAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateUserCommandRequest, string, UpdateUserCommandResponse>(
            p => p.Email,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForEmailAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
            p => p.Email,
            messageTransformer,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForProfileImageAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateUserCommandRequest, string, UpdateUserCommandResponse>(
            p => p.ProfileImageUrl!,
            messageTransformer!,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForProfileImageAsync(
        this IApplicationSender sender,
        IStringMessageTransformer messageTransformer,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, string, AddUserCommandResponse>(
            p => p.ProfileImageUrl!,
            messageTransformer!,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForCreatedAtUtcAsync(
        this IApplicationSender sender,
        IDateTimeOffsetMessageTransformer messageTransformer,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, DateTimeOffset, AddUserCommandResponse>(
            p => p.CreatedAtUtc,
            messageTransformer!,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUpdatedAtUtcAsync(
        this IApplicationSender sender,
        IDateTimeOffsetMessageTransformer messageTransformer,
        AddUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<AddUserCommandRequest, DateTimeOffset, AddUserCommandResponse>(
            p => p.UpdatedAtUtc,
            messageTransformer!,
            request,
            cancellationToken);
    }

    public static async Task ShouldThrowInvalidValidationExceptionForUpdatedAtUtcAsync(
        this IApplicationSender sender,
        IDateTimeOffsetMessageTransformer messageTransformer,
        UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await sender.ShouldThrowInvalidValidationExceptionAsync<UpdateUserCommandRequest, DateTimeOffset, UpdateUserCommandResponse>(
            p => p.UpdatedAtUtc,
            messageTransformer!,
            request,
            cancellationToken);
    }
}
