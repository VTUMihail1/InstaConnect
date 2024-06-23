using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace InstaConnect.Shared.Web.Extensions;
public static class WebApplicationExtensions
{
    public static WebApplication UseSwaggerUI(this WebApplication webApplication)
    {
        webApplication.UseSwaggerUI(
            options =>
            {
                var descriptions = webApplication.DescribeApiVersions();

                foreach (var description in descriptions)
                {
                    string url = $"/swagger/{description.GroupName}/swagger.json";
                    string name = description.GroupName.ToUpperInvariant();

                    options.SwaggerEndpoint(url, name);
                }
            });

        return webApplication;
    }
}
