// Filters/MasterOnlyAttribute.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AgendaPro.Filters
{
    public class MasterOnlyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var isMaster = context.HttpContext.Session.GetString("IsMaster");

            if (string.IsNullOrEmpty(isMaster) || !bool.TryParse(isMaster, out bool isMasterBool) || !isMasterBool)
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
                return;
            }

            await next();
        }
    }
}
