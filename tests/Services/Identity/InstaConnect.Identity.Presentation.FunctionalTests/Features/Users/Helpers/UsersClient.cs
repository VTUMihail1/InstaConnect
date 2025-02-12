using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;
using InstaConnect.Identity.Presentation.Features.Users.Models.Requests;
using InstaConnect.Identity.Presentation.Features.Users.Models.Responses;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Abstractions;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Utilities;
using InstaConnect.Shared.Common.Utilities;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Helpers;
public class UsersClient : IUsersClient
{
    private readonly HttpClient _httpClient;

    public UsersClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> GetAllStatusCodeAsync(
        GetAllUsersRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserPaginationQueryResponse> GetAllAsync(
        GetAllUsersRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient
            .GetFromJsonAsync<UserPaginationQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<UserPaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .GetFromJsonAsync<UserPaginationQueryResponse>(UserTestRoutes.Default, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetByIdStatusCodeAsync(
        GetUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserQueryResponse> GetByIdAsync(
        GetUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient
            .GetFromJsonAsync<UserQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetDetailedByIdStatusCodeAsync(
        GetDetailedUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id },
                { AppClaims.Admin, AppClaims.Admin }
            });

        var route = IdDetailedRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> GetDetailedByIdStatusCodeUnathorizedAsync(
        GetDetailedUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdDetailedRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> GetDetailedByIdStatusCodeNonAdminAsync(
        GetDetailedUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id }
            });

        var route = IdDetailedRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserDetailedQueryResponse> GetDetailedByIdAsync(
        GetDetailedUserByIdRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id },
                { AppClaims.Admin, AppClaims.Admin }
            });

        var route = IdDetailedRoute(request.Id);
        var response = await _httpClient
            .GetFromJsonAsync<UserDetailedQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetByNameStatusCodeAsync(
        GetUserByNameRequest request,
        CancellationToken cancellationToken)
    {
        var route = NameRoute(request.UserName);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserQueryResponse> GetByNameAsync(
        GetUserByNameRequest request,
        CancellationToken cancellationToken)
    {
        var route = NameRoute(request.UserName);
        var response = await _httpClient
            .GetFromJsonAsync<UserQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetCurrentStatusCodeAsync(
        GetCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id }
            });

        var response = await _httpClient
            .GetAsync(UserTestRoutes.Current, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> GetCurrentStatusCodeUnauthorizedAsync(
        GetCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .GetAsync(UserTestRoutes.Current, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserQueryResponse> GetCurrentAsync(
        GetCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.Id }
        });

        var httpResponseMessage = await _httpClient
            .GetAsync(UserTestRoutes.Current, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<UserQueryResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetCurrentDetailedStatusCodeAsync(
        GetCurrentDetailedUserRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id }
            });

        var response = await _httpClient
            .GetAsync(UserTestRoutes.CurrentDetailed, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> GetCurrentDetailedStatusCodeUnauthorizedAsync(
        GetCurrentDetailedUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .GetAsync(UserTestRoutes.CurrentDetailed, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserDetailedQueryResponse> GetCurrentDetailedAsync(
        GetCurrentDetailedUserRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.Id }
        });

        var httpResponseMessage = await _httpClient
            .GetAsync(UserTestRoutes.CurrentDetailed, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<UserDetailedQueryResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> AddStatusCodeAsync(
        AddUserRequest request,
        CancellationToken cancellationToken)
    {
        var requestForm = GetForm(request.Form);
        var response = await _httpClient
            .PostAsync(UserTestRoutes.Default, requestForm, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserCommandResponse> AddAsync(
        AddUserRequest request,
        CancellationToken cancellationToken)
    {
        var requestForm = GetForm(request.Form);
        var httpResponseMessage = await _httpClient
            .PostAsync(UserTestRoutes.Default, requestForm, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<UserCommandResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> LoginStatusCodeAsync(
        LoginUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .PostAsJsonAsync(UserTestRoutes.Login, request.Body, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserTokenCommandResponse> LoginAsync(
        LoginUserRequest request,
        CancellationToken cancellationToken)
    {
        var httpResponseMessage = await _httpClient
            .PostAsJsonAsync(UserTestRoutes.Login, request.Body, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<UserTokenCommandResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> UpdateCurrentStatusCodeAsync(
        UpdateCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        var requestForm = GetForm(request.Form);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id }
            });

        var response = await _httpClient
            .PutAsync(UserTestRoutes.Current, requestForm, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> UpdateCurrentStatusCodeUnauthorizedAsync(
        UpdateCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        var requestForm = GetForm(request.Form);

        var response = await _httpClient
            .PutAsync(UserTestRoutes.Current, requestForm, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserCommandResponse> UpdateCurrentAsync(
        UpdateCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        var requestForm = GetForm(request.Form);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
        {
            { ClaimTypes.NameIdentifier, request.Id }
        });

        var httpResponseMessage = await _httpClient
            .PutAsync(UserTestRoutes.Current, requestForm, cancellationToken);
        var response = await httpResponseMessage.Content.ReadFromJsonAsync<UserCommandResponse>(cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeAsync(
        DeleteUserRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id },
                { AppClaims.Admin, AppClaims.Admin }
            });

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(
        DeleteUserRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeNonAdminAsync(
        DeleteUserRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id }
            });

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task DeleteAsync(
        DeleteUserRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id },
                { AppClaims.Admin, AppClaims.Admin }
            });

        await _httpClient.DeleteAsync(route, cancellationToken);
    }

    public async Task<HttpStatusCode> DeleteCurrentStatusCodeAsync(
        DeleteCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id }
            });

        var response = await _httpClient.DeleteAsync(UserTestRoutes.Current, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> DeleteCurrentStatusCodeUnauthorizedAsync(
        DeleteCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.DeleteAsync(UserTestRoutes.Current, cancellationToken);

        return response.StatusCode;
    }

    public async Task DeleteCurrentAsync(
        DeleteCurrentUserRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id }
            });

        await _httpClient.DeleteAsync(UserTestRoutes.Current, cancellationToken);
    }

    private string GetAllRoute(GetAllUsersRequest request)
    {
        var route = string.Format(
            UserTestRoutes.GetAll,
            request.UserName,
            request.FirstName,
            request.LastName,
            request.SortOrder,
            request.SortPropertyName,
            request.Page,
            request.PageSize);

        return route;
    }

    private string IdRoute(string id)
    {
        var route = string.Format(
            UserTestRoutes.Id,
            id);

        return route;
    }

    private string IdDetailedRoute(string id)
    {
        var route = string.Format(
            UserTestRoutes.IdDetailed,
            id);

        return route;
    }

    private string NameRoute(string name)
    {
        var route = string.Format(
            UserTestRoutes.Name,
            name);

        return route;
    }

    private MultipartFormDataContent GetForm(AddUserForm form)
    {
        var multipartContent = new MultipartFormDataContent
        {
            { new StringContent(form.UserName), nameof(form.UserName) },
            { new StringContent(form.Email), nameof(form.Email) },
            { new StringContent(form.Password), nameof(form.Password) },
            { new StringContent(form.ConfirmPassword), nameof(form.ConfirmPassword) },
            { new StringContent(form.FirstName), nameof(form.FirstName) },
            { new StringContent(form.LastName), nameof(form.LastName) }
        };

        if (form.ProfileImage != null)
        {
            var streamContent = new StreamContent(form.ProfileImage.OpenReadStream());
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(form.ProfileImage.ContentType);
            multipartContent.Add(streamContent, nameof(form.ProfileImage), form.ProfileImage.FileName);
        }

        return multipartContent;
    }

    private MultipartFormDataContent GetForm(UpdateUserForm form)
    {
        var multipartContent = new MultipartFormDataContent
        {
            { new StringContent(form.UserName), nameof(form.UserName) },
            { new StringContent(form.FirstName), nameof(form.FirstName) },
            { new StringContent(form.LastName), nameof(form.LastName) }
        };

        if (form.ProfileImage != null)
        {
            var streamContent = new StreamContent(form.ProfileImage.OpenReadStream());
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(form.ProfileImage.ContentType);
            multipartContent.Add(streamContent, nameof(form.ProfileImage), form.ProfileImage.FileName);
        }

        return multipartContent;
    }
}
