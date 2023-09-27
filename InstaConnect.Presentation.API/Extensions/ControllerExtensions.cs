using InstaConnect.Business.Models.Enums;
using InstaConnect.Business.Models.Results;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Presentation.API.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult HandleResponse<T>(this ControllerBase controller, IResult<T> response)
        {
            if (response.StatusCode == InstaConnectStatusCode.NotFound)
            {
                return controller.NotFound(response.ErrorMessages);
            }
            else if (response.StatusCode == InstaConnectStatusCode.BadRequest)
            {
                return controller.BadRequest(response.ErrorMessages);
            }
            else if (response.StatusCode == InstaConnectStatusCode.Unauthorized)
            {
                return controller.Unauthorized(response.ErrorMessages);
            }
            else if (response.StatusCode == InstaConnectStatusCode.Forbidden)
            {
                return controller.Forbid();
            }
            else if (response.StatusCode == InstaConnectStatusCode.OK)
            {
                return controller.Ok(response.Data);
            }
            else if (response.StatusCode == InstaConnectStatusCode.NoContent)
            {
                return controller.NoContent();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
