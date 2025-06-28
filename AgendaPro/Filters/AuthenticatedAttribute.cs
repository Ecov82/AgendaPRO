using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace AgendaPro.Filters
{
    public class AuthenticatedAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Verifica se o controller ou action tem o atributo [AllowAnonymous]
            var hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata
                .Any(em => em.GetType().Name == "AllowAnonymousAttribute");

            if (hasAllowAnonymous)
            {
                await next();
                return;
            }

            // Verifica se o usuário está autenticado via sessão
            var userId = context.HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            await next();
        }
    }
}
