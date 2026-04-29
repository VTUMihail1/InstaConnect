using System.Net;
using System.Net.Http.Json;

using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;
using InstaConnect.Identity.Presentation.Features.Users.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Utilities;

public static class UserClient
{
	extension(HttpClient httpClient)
	{
		private async Task<HttpResponseMessage> GetAllUsersResponseMessageAsync(
			GetAllUsersApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetAllUsersProblemDetailsAsync(
			GetAllUsersApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllUsersResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetAllUsersApiResponse> GetAllUsersAsync(
			GetAllUsersApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllUsersResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetAllUsersApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetAllUsersStatusCodeAsync(
			GetAllUsersApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetAllUsersResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> GetUserByIdResponseMessageAsync(
			GetUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetUserByIdProblemDetailsAsync(
			GetUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetUserByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetUserByIdApiResponse> GetUserByIdAsync(
			GetUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetUserByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetUserByIdApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetUserByIdStatusCodeAsync(
			GetUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetUserByIdResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> GetCurrentUserByIdUnauthorizedResponseMessageAsync(
			GetCurrentUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> GetCurrentUserByIdResponseMessageAsync(
			GetCurrentUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAdminAuthorization(request.CurrentId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetCurrentUserByIdProblemDetailsUnauthorizedAsync(
			GetCurrentUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetCurrentUserByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetCurrentUserByIdProblemDetailsAsync(
			GetCurrentUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetCurrentUserByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetCurrentUserByIdApiResponse> GetCurrentUserByIdAsync(
			GetCurrentUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetCurrentUserByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetCurrentUserByIdApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetCurrentUserByIdStatusCodeUnauthorizedAsync(
			GetCurrentUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetCurrentUserByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> GetCurrentUserByIdStatusCodeAsync(
			GetCurrentUserByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetCurrentUserByIdResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> GetUserDetailsByIdUnauthorizedResponseMessageAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> GetUserDetailsByIdForbiddenResponseMessageAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentId)
				.GetAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> GetUserDetailsByIdResponseMessageAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAdminAuthorization(request.CurrentId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetUserDetailsByIdUnauthorizedProblemDetailsAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetUserDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetUserDetailsByIdForbiddenProblemDetailsAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetUserDetailsByIdForbiddenResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetUserDetailsByIdProblemDetailsAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetUserDetailsByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetUserDetailsByIdApiResponse> GetUserDetailsByIdAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetUserDetailsByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetUserDetailsByIdApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetUserDetailsByIdStatusCodeUnauthorizedAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetUserDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> GetUserDetailsByIdStatusCodeForbiddenAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetUserDetailsByIdForbiddenResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> GetUserDetailsByIdStatusCodeAsync(
			GetUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetUserDetailsByIdResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> GetCurrentUserDetailsByIdUnauthorizedResponseMessageAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.GetAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> GetCurrentUserDetailsByIdResponseMessageAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentId)
				.GetAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetCurrentUserDetailsByIdProblemDetailsUnauthorizedAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetCurrentUserDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> GetCurrentUserDetailsByIdProblemDetailsAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetCurrentUserDetailsByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<GetCurrentUserDetailsByIdApiResponse> GetCurrentUserDetailsByIdAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetCurrentUserDetailsByIdResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<GetCurrentUserDetailsByIdApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> GetCurrentUserDetailsByIdStatusCodeUnauthorizedAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetCurrentUserDetailsByIdUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> GetCurrentUserDetailsByIdStatusCodeAsync(
			GetCurrentUserDetailsByIdApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.GetCurrentUserDetailsByIdResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> AddUserResponseMessageAsync(
			AddUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.PostAsync(route, request.Form.GetContent(), cancellationToken);
		}

		public async Task<ApplicationProblemDetails> AddUserProblemDetailsAsync(
			AddUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddUserResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<AddUserApiResponse> AddUserAsync(
			AddUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddUserResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<AddUserApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> AddUserStatusCodeAsync(
			AddUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.AddUserResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> UpdateCurrentUserUnauthorizedResponseMessageAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.PutAsJsonAsync(route, request.Form.GetContent(), cancellationToken);
		}

		private async Task<HttpResponseMessage> UpdateCurrentUserResponseMessageAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.Id)
				.PutAsync(route, request.Form.GetContent(), cancellationToken);
		}

		public async Task<ApplicationProblemDetails> UpdateCurrentUserProblemDetailsUnauthorizedAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.UpdateCurrentUserUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> UpdateCurrentUserProblemDetailsAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.UpdateCurrentUserResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<UpdateCurrentUserApiResponse> UpdateCurrentUserAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.UpdateCurrentUserResponseMessageAsync(request, cancellationToken);

			return await response.GetFromJsonAsync<UpdateCurrentUserApiResponse>(cancellationToken);
		}

		public async Task<HttpStatusCode> UpdateCurrentUserStatusCodeUnauthorizedAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.UpdateCurrentUserUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> UpdateCurrentUserStatusCodeAsync(
			UpdateCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.UpdateCurrentUserResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> DeleteUserUnauthorizedResponseMessageAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> DeleteUserForbiddenResponseMessageAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.Id)
				.DeleteAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> DeleteUserResponseMessageAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAdminAuthorization(request.Id)
				.DeleteAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> DeleteUserProblemDetailsUnauthorizedAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteUserUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> DeleteUserForbiddenProblemDetailsAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteUserForbiddenResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> DeleteUserProblemDetailsAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteUserResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task DeleteUserAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await httpClient.DeleteUserResponseMessageAsync(request, cancellationToken);
		}

		public async Task<HttpStatusCode> DeleteUserStatusCodeUnauthorizedAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteUserUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> DeleteUserStatusCodeForbiddenAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteUserForbiddenResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> DeleteUserStatusCodeAsync(
			DeleteUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteUserResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		private async Task<HttpResponseMessage> DeleteCurrentUserUnauthorizedResponseMessageAsync(
			DeleteCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.DeleteAsync(route, cancellationToken);
		}

		private async Task<HttpResponseMessage> DeleteCurrentUserResponseMessageAsync(
			DeleteCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var route = UserRouteFactory.GetRoute(request);

			return await httpClient
				.WithAuthorization(request.CurrentId)
				.DeleteAsync(route, cancellationToken);
		}

		public async Task<ApplicationProblemDetails> DeleteCurrentUserProblemDetailsUnauthorizedAsync(
			DeleteCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteCurrentUserUnauthorizedResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task<ApplicationProblemDetails> DeleteCurrentUserProblemDetailsAsync(
			DeleteCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteCurrentUserResponseMessageAsync(request, cancellationToken);

			return await response.GetProblemDetailsFromJsonAsync(cancellationToken);
		}

		public async Task DeleteCurrentUserAsync(
			DeleteCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			await httpClient.DeleteCurrentUserResponseMessageAsync(request, cancellationToken);
		}

		public async Task<HttpStatusCode> DeleteCurrentUserStatusCodeUnauthorizedAsync(
			DeleteCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteCurrentUserUnauthorizedResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}

		public async Task<HttpStatusCode> DeleteCurrentUserStatusCodeAsync(
			DeleteCurrentUserApiRequest request,
			CancellationToken cancellationToken)
		{
			var response = await httpClient.DeleteCurrentUserResponseMessageAsync(request, cancellationToken);

			return response.GetStatusCode();
		}
	}
}
