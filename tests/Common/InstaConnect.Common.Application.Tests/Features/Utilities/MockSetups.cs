using InstaConnect.Common.Application.Features.Requests.Abstractions;
using InstaConnect.Common.Tests.Features.Utilities;

using MediatR;

namespace InstaConnect.Common.Application.Tests.Features.Utilities;

public static class MockSetups
{
	extension(IApplicationSender sender)
	{
		public void SetupSendAsync<TRequest, TResponse>(
			TRequest request,
			TResponse response,
			CancellationToken cancellationToken)
			where TRequest : IRequest<TResponse>
		{
			sender
				.SendAsync(request, cancellationToken)
				.ReturnsTaskResponse(response);
		}
	}
}
