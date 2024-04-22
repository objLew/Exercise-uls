using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace uls_task.Server.Controllers
{
    public class AuthorizationFilter : IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // this could be more in depth but for simplicity we will just check for a hard-coded header

            if (context.HttpContext.Request.Headers.ContainsKey("ShhhhThisIsASecret"))
            {
                string secret = context.HttpContext.Request.Headers["ShhhhThisIsASecret"];

                if (string.IsNullOrEmpty(secret))
                {
                    // return unauthorized
                    context.Result = new StatusCodeResult(403);

                    return;
                }
            }

            // continue to controller
            return;

        }


    }
}
