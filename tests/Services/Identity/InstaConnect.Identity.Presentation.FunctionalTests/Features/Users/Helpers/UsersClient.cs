using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;

using InstaConnect.Identity.Presentation.Features.Users.Models.Forms;
using InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Abstractions;

namespace InstaConnect.Identity.Presentation.FunctionalTests.Features.Users.Helpers;
public class UsersClient : IUsersClient
{
    private readonly HttpClient _httpClient;

    public UsersClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpStatusCode> GetAllStatusCodeAsync(
        GetAllUsersApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = GetAllRoute(request);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserPaginationQueryResponse> GetAllAsync(
        GetAllUsersApiRequest request,
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
        GetUserByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserQueryResponse> GetByIdAsync(
        GetUserByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);
        var response = await _httpClient
            .GetFromJsonAsync<UserQueryResponse>(route, cancellationToken);

        return response;
    }

    public async Task<HttpStatusCode> GetDetailedByIdStatusCodeAsync(
        GetUserDetailsByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id },
                { ApplicationClaims.Admin, ApplicationClaims.Admin }
            });

        var route = IdDetailedRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> GetDetailedByIdStatusCodeUnathorizedAsync(
        GetUserDetailsByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdDetailedRoute(request.Id);
        var response = await _httpClient.GetAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> GetDetailedByIdStatusCodeNonAdminAsync(
        GetUserDetailsByIdApiRequest request,
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
        GetUserDetailsByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id },
                { ApplicationClaims.Admin, ApplicationClaims.Admin }
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
        GetCurrentUserByIdApiRequest request,
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
        GetCurrentUserByIdApiRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .GetAsync(UserTestRoutes.Current, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserQueryResponse> GetCurrentAsync(
        GetCurrentUserByIdApiRequest request,
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
        GetCurrentUserDetailsApiRequest request,
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
        GetCurrentUserDetailsApiRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .GetAsync(UserTestRoutes.CurrentDetailed, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserDetailedQueryResponse> GetCurrentDetailedAsync(
        GetCurrentUserDetailsApiRequest request,
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
        AddUserApiRequest request,
        CancellationToken cancellationToken)
    {
        var requestForm = GetForm(request.Form);
        var response = await _httpClient
            .PostAsync(UserTestRoutes.Default, requestForm, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserCommandResponse> AddAsync(
        AddUserApiRequest request,
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
        UpdateCurrentUserApiRequest request,
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
        UpdateCurrentUserApiRequest request,
        CancellationToken cancellationToken)
    {
        var requestForm = GetForm(request.Form);

        var response = await _httpClient
            .PutAsync(UserTestRoutes.Current, requestForm, cancellationToken);

        return response.StatusCode;
    }

    public async Task<UserCommandResponse> UpdateCurrentAsync(
        UpdateCurrentUserApiRequest request,
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
        DeleteUserApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id },
                { ApplicationClaims.Admin, ApplicationClaims.Admin }
            });

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(
        DeleteUserApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        var response = await _httpClient.DeleteAsync(route, cancellationToken);

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> DeleteStatusCodeNonAdminAsync(
        DeleteUserApiRequest request,
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
        DeleteUserApiRequest request,
        CancellationToken cancellationToken)
    {
        var route = IdRoute(request.Id);

        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id },
                { ApplicationClaims.Admin, ApplicationClaims.Admin }
            });

        await _httpClient.DeleteAsync(route, cancellationToken);
    }

    public async Task<HttpStatusCode> DeleteCurrentStatusCodeAsync(
        DeleteCurrentUserApiRequest request,
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
        DeleteCurrentUserApiRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient.DeleteAsync(UserTestRoutes.Current, cancellationToken);

        return response.StatusCode;
    }

    public async Task DeleteCurrentAsync(
        DeleteCurrentUserApiRequest request,
        CancellationToken cancellationToken)
    {
        _httpClient.SetFakeJwtBearerToken(new Dictionary<string, object>()
            {
                { ClaimTypes.NameIdentifier, request.Id }
            });

        await _httpClient.DeleteAsync(UserTestRoutes.Current, cancellationToken);
    }

    private static string GetAllRoute(GetAllUsersApiRequest request)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
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

    private static string IdRoute(string id)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
            UserTestRoutes.Id,
            id);

        return route;
    }

    private static string IdDetailedRoute(string id)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
            UserTestRoutes.IdDetailed,
            id);

        return route;
    }

    private static string NameRoute(string name)
    {
        var route = string.Format(
            CultureInfo.InvariantCulture,
            UserTestRoutes.Name,
            name);

        return route;
    }

    private static MultipartFormDataContent GetForm(AddUserApiForm form)
    {
        var multipartContent = new MultipartFormDataContent
    {
        { GetStringContent(form.UserName), nameof(form.UserName) },
        { GetStringContent(form.Email), nameof(form.Email) },
        { GetStringContent(form.Password), nameof(form.Password) },
        { GetStringContent(form.ConfirmPassword), nameof(form.ConfirmPassword) },
        { GetStringContent(form.FirstName), nameof(form.FirstName) },
        { GetStringContent(form.LastName), nameof(form.LastName) }
    };

        if (form.ProfileImage != null)
        {
            var streamContent = GetStreamContent(form.ProfileImage.OpenReadStream());
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(form.ProfileImage.ContentType);
            multipartContent.Add(streamContent, nameof(form.ProfileImage), form.ProfileImage.FileName);
        }

        return multipartContent;
    }

    private static MultipartFormDataContent GetForm(UpdateUserApiForm form)
    {
        var multipartContent = new MultipartFormDataContent
        {
            { GetStringContent(form.UserName), nameof(form.UserName) },
            { GetStringContent(form.FirstName), nameof(form.FirstName) },
            { GetStringContent(form.LastName), nameof(form.LastName) }
        };

        if (form.ProfileImage != null)
        {
            var streamContent = GetStreamContent(form.ProfileImage.OpenReadStream());
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(form.ProfileImage.ContentType);
            multipartContent.Add(streamContent, nameof(form.ProfileImage), form.ProfileImage.FileName);
        }

        return multipartContent;
    }

    private static StringContent GetStringContent(string content)
    {
        var stringContent = new StringContent(content);

        return stringContent;
    }

    private static StreamContent GetStreamContent(Stream content)
    {
        var streamContent = new StreamContent(content);

        return streamContent;
    }
}
