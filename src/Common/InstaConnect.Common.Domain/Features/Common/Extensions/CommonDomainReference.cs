using System.Reflection;

namespace InstaConnect.Common.Domain.Features.Common.Extensions;

public static class CommonDomainReference
{
	public static readonly Assembly Assembly = typeof(CommonDomainReference).Assembly;
}
