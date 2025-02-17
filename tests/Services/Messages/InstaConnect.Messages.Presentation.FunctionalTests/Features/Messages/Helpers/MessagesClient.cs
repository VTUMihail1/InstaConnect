using System.Globalization;
using System.Net.Http.Json;
using System.Security.Claims;

using InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Abstractions;

namespace InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Helpers;
public class MessagesClient : IMessagesClient
{
    private readonly HttpClient _httpClient;

    public MessagesClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> GetAllStatusCodeUnauthorizedAsync(
        GetAllMessagesRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> GetAllStatusCodeAsync(
        GetAllMessagesRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var route = GetAllRoute(request);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<MessagePaginationQueryResponse> GetAllAsync(
        GetAllMessagesRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var route = GetAllRoute(request);
        var response = await _httpClient
            .GetFromJsonAsync<MessagePaginationQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<MessagePaginationQueryResponse> GetAllAsync(
        string currentUserId,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, currentUserId }
        });

        var response = await _httpClient
            .GetFromJsonAsync<MessagePaginationQueryResponse>(MessageTestRoutes.Default, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
        GetMessageByIdRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var route = IdRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<MessageQueryResponse> GetByIdAsync(
        GetMessageByIdRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var route = IdRoute(request.Id);
        var response = await _httpClient
            .GetFromJsonAsync<MessageQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetByIdStatusCodeUnathorizedAsync(
        GetMessageByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> AddStatusCodeAsync(
        AddMessageRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        var response = await _httpClient
            .PostAsJsonAsync(MessageTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(
        AddMessageRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .PostAsJsonAsync(MessageTestRoutes.Default, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<MessageCommandResponse> AddAsync(
        AddMessageRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var httpResponseMessage = await _httpClient
            .PostAsJsonAsync(MessageTestRoutes.Default, request.Body, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<MessageCommandResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> UpdateStatusCodeAsync(
        UpdateMessageRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        var response = await _httpClient
            .PutAsJsonAsync(route, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> UpdateStatusCodeUnauthorizedAsync(
        UpdateMessageRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        var response = await _httpClient
            .PutAsJsonAsync(route, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<MessageCommandResponse> UpdateAsync(
        UpdateMessageRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.CurrentUserId }
        });

        var httpResponseMessage = await _httpClient
            .PutAsJsonAsync(route, request.Body, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<MessageCommandResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeAsync(
        DeleteMessageRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(
        DeleteMessageRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task DeleteAsync(
        DeleteMessageRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.CurrentUserId }
            });

        await _httpClient.DeleteAsync(route, cancellationToken);
    }

    private string GetAllRoute(GetAllMessagesRequest request)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
            MessageTestRoutes.GetAll,
            request.ReceiverId,
            request.ReceiverName,
            request.SortOrder,
            request.SortPropertyName,
            request.Page,
            request.PageSize);

        return route;
    }

    private string IdRoute(string id)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
            MessageTestRoutes.Id,
            id);

        return route;
    }
}
