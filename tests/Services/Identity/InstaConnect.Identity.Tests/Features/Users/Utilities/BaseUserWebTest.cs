using InstaConnect.Common.Domain.Features.Images.Abstractions;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace InstaConnect.Identity.Tests.Features.Users.Utilities;

public abstract class BaseUserWebTest : BaseUserTest, IClassFixture<IdentityWebApplicationFactory>
{
	protected IServiceScope ServiceScope { get; }

	protected IImageHandler ImageHandler { get; }

	protected BaseUserWebTest(IdentityWebApplicationFactory webApplicationFactory) : base(webApplicationFactory.Services.GetPasswordHasher())
	{
		ServiceScope = webApplicationFactory.Services.CreateScope();
		ImageHandler = ServiceScope.GetImageHandler();
	}
}
