using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

public class ApplicationProblemDetails : ProblemDetails
{
	public IEnumerable<string>? Errors { get; set; }

	public ApplicationProblemDetails()
	{
	}
}
