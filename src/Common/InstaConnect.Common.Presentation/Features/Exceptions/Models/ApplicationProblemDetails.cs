using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.Features.Exceptions.Models;

public class ApplicationProblemDetails : ProblemDetails
{
	public IEnumerable<string>? Errors { get; set; }

	public ApplicationProblemDetails()
	{
	}
}
