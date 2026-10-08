using FluentValidation.Results;

using InstaConnect.Common.Domain.Features.AccessTokens.Models;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Requests.Abstractions;
using InstaConnect.Common.Infrastructure.Features.Databases.Helpers;

namespace InstaConnect.Common.Domain.Tests.Features.Utilities;

public static class CommonEquals
{
	extension(AccessToken response)
	{
		public bool Matches()
		{
			return response.Value.IsNotNullOrEmptyOrWhiteSpace() &&
				   response.ExpiresAtUtc != default;
		}
	}

	extension(ValidationFailure v)
	{
		public bool Matches(
		string errorMessage)
		{
			return v.ErrorMessage.EqualsOrdinalIgnoreCase(errorMessage);
		}
	}

	extension<TResponse>(TResponse response) where TResponse : ICollectionResponse
	{
		public bool MatchesCollectionResponse<TQuery>(
		TQuery request,
		int totalCount)
			where TQuery : IPaginationQuery
		{
			var paginator = new Paginator();

			return response.Page == request.Page &&
				   response.PageSize == request.PageSize &&
				   response.TotalCount == totalCount &&
				   response.HasPreviousPage == paginator.HasPreviousPage(response.Page) &&
				   response.HasNextPage == paginator.HasNextPage(response.Page, response.PageSize, response.TotalCount);
		}
	}
}
