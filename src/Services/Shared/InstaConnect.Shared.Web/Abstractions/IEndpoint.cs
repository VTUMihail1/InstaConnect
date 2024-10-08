using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace InstaConnect.Shared.Web.Abstractions;

public interface IEndpoint
{
    void Map(IEndpointRouteBuilder endpointRouteBuilder);
}
