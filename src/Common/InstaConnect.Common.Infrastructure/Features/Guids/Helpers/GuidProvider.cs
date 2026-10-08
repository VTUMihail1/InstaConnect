using InstaConnect.Common.Domain.Features.Guids.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Guids.Helpers;

public class GuidProvider : IGuidProvider
{
	public string NewStringGuid()
	{
		return Guid.NewGuid().ToString();
	}
}
