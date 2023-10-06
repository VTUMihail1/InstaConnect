using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace InstaConnect.Presentation.API.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ValidateUserAttribute : ActionFilterAttribute
    {
        private readonly string _userIdentifierName;

        public ValidateUserAttribute(string userIdentifierName)
        {
            _userIdentifierName = userIdentifierName;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentUserId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var DTO = context.ActionArguments.Values.FirstOrDefault(arg => arg.GetType().GetProperty(_userIdentifierName) != null);

            if (DTO != null)
            {
                var DTOUserId = DTO.GetType().GetProperty(_userIdentifierName).GetValue(DTO)?.ToString();

                if (currentUserId != DTOUserId)
                {
                    context.Result = new UnauthorizedResult();

                    return;
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
