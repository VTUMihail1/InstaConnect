using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.Tests.Features.Extensions;

public static class ActionResultExtensions
{
	extension<T>(ActionResult<T> actionResult)
		where T : class
	{
		public T GetValue()
		{
			return (T)((ObjectResult)actionResult.Result!).Value!;
		}
	}
}
