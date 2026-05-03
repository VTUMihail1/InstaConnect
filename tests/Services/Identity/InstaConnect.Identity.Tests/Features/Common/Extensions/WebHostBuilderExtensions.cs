using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Common.Models.Options;
using InstaConnect.Identity.Tests.Features.Common.Utilities;

using Microsoft.AspNetCore.Hosting;

namespace InstaConnect.Identity.Tests.Features.Common.Extensions;

public static class WebHostBuilderExtensions
{
	extension(IWebHostBuilder webHostBuilder)
	{
		public void UpdateAdminConfiguration()
		{
			webHostBuilder.UseSetting(
				AdminOptions.SectionName.FormatCurrentCultureSectionKey(nameof(AdminOptions.Email)),
				IdentityMockValues.AdminEmail);

			webHostBuilder.UseSetting(
				AdminOptions.SectionName.FormatCurrentCultureSectionKey(nameof(AdminOptions.Password)),
				IdentityMockValues.AdminPassword);
		}
	}
}
