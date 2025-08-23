using System.Threading;

using InstaConnect.Common.Application.Contracts.Users;
using InstaConnect.Common.Tests.Utilities.Events;

namespace InstaConnect.Users.Common.Tests.Features.Users.Utilities;

public static class UserEventHarness
{
    public static async Task<bool> HasConsumedUserAddedEventRequestAsync(
        this IEventHarness eventHarness,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.ConsumedAsync<UserAddedEventRequest>(u => u.Id == request.Id &&
                                                                                     u.FirstName == request.FirstName &&
                                                                                     u.LastName == request.LastName &&
                                                                                     u.Email == request.Email &&
                                                                                     u.Name == request.Name &&
                                                                                     u.ProfileImage == request.ProfileImage, cancellationToken);

        return result;
    }

    public static async Task<bool> HasConsumedUserUpdatedEventRequestAsync(
        this IEventHarness eventHarness,
        UserUpdatedEventRequest request,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.ConsumedAsync<UserUpdatedEventRequest>(u => u.Id == request.Id &&
                                                                              u.FirstName == request.FirstName &&
                                                                              u.LastName == request.LastName &&
                                                                              u.Email == request.Email &&
                                                                              u.Name == request.Name &&
                                                                              u.ProfileImage == request.ProfileImage, cancellationToken);

        return result;
    }

    public static async Task<bool> HasConsumedUserDeletedEventRequestAsync(
        this IEventHarness eventHarness,
        UserDeletedEventRequest request,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.ConsumedAsync<UserDeletedEventRequest>(p => p.Id == request.Id, cancellationToken);

        return result;
    }

    public static async Task<bool> HasFaultedUserAddedEventRequestAsync(
        this IEventHarness eventHarness,
        UserAddedEventRequest request,
        string errorMessage,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.FaultedAsync<UserAddedEventRequest>(u => u.Id == request.Id &&
                                                                                     u.FirstName == request.FirstName &&
                                                                                     u.LastName == request.LastName &&
                                                                                     u.Email == request.Email &&
                                                                                     u.Name == request.Name &&
                                                                                     u.ProfileImage == request.ProfileImage, errorMessage, cancellationToken);

        return result;
    }

    public static async Task<bool> HasFaultedUserUpdatedEventRequestAsync(
        this IEventHarness eventHarness,
        UserUpdatedEventRequest request,
        string errorMessage,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.FaultedAsync<UserUpdatedEventRequest>(u => u.Id == request.Id &&
                                                                              u.FirstName == request.FirstName &&
                                                                              u.LastName == request.LastName &&
                                                                              u.Email == request.Email &&
                                                                              u.Name == request.Name &&
                                                                              u.ProfileImage == request.ProfileImage, errorMessage, cancellationToken);

        return result;
    }

    public static async Task<bool> HasFaultedUserDeletedEventRequestAsync(
        this IEventHarness eventHarness,
        UserDeletedEventRequest request,
        string errorMessage,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.FaultedAsync<UserDeletedEventRequest>(p => p.Id == request.Id, errorMessage, cancellationToken);

        return result;
    }

    public static async Task<bool> HasFaultedUserAddedEventRequestWithNotFoundMessageAsync(
        this IEventHarness eventHarness,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.HasFaultedUserAddedEventRequestAsync(request, UserExceptionErrorMessages.GetNotFoundMessage(request.Id), cancellationToken);

        return result;
    }

    public static async Task<bool> HasFaultedUserUpdatedEventRequestWithNotFoundMessageAsync(
        this IEventHarness eventHarness,
        UserUpdatedEventRequest request,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.HasFaultedUserUpdatedEventRequestAsync(request, UserExceptionErrorMessages.GetNotFoundMessage(request.Id), cancellationToken);

        return result;
    }

    public static async Task<bool> HasFaultedUserDeletedEventRequestWithNotFoundMessageAsync(
        this IEventHarness eventHarness,
        UserDeletedEventRequest request,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.HasFaultedUserDeletedEventRequestAsync(request, UserExceptionErrorMessages.GetNotFoundMessage(request.Id), cancellationToken);

        return result;
    }

    public static async Task<bool> HasFaultedUserAddedEventRequestWithAlreadyExistsMessageAsync(
        this IEventHarness eventHarness,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.HasFaultedUserAddedEventRequestAsync(request, UserExceptionErrorMessages.GetAlreadyExistsMessage(request.Id), cancellationToken);

        return result;
    }

    public static async Task<bool> HasFaultedUserAddedEventRequestWithNameAlreadyExistsMessageAsync(
        this IEventHarness eventHarness,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.HasFaultedUserAddedEventRequestAsync(request, UserExceptionErrorMessages.GetNameAlreadyExistsMessage(request.Name), cancellationToken);

        return result;
    }

    public static async Task<bool> HasFaultedUserUpdatedEventRequestWithNameAlreadyExistsMessageAsync(
        this IEventHarness eventHarness,
        UserUpdatedEventRequest request,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.HasFaultedUserUpdatedEventRequestAsync(request, UserExceptionErrorMessages.GetNameAlreadyExistsMessage(request.Name), cancellationToken);

        return result;
    }

    public static async Task<bool> HasFaultedUserAddedEventRequestWithEmailAlreadyExistsMessageAsync(
        this IEventHarness eventHarness,
        UserAddedEventRequest request,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.HasFaultedUserAddedEventRequestAsync(request, UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(request.Email), cancellationToken);

        return result;
    }

    public static async Task<bool> HasFaultedUserUpdatedEventRequestWithEmailAlreadyExistsMessageAsync(
        this IEventHarness eventHarness,
        UserUpdatedEventRequest request,
        CancellationToken cancellationToken)
    {
        var result = await eventHarness.HasFaultedUserUpdatedEventRequestAsync(request, UserExceptionErrorMessages.GetEmailAlreadyExistsMessage(request.Email), cancellationToken);

        return result;
    }
}
