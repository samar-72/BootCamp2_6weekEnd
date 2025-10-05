using Microsoft.AspNetCore.Mvc.Filters;

namespace BootCamp2_6weekEnd.Filters
{
    public class SessionAuthourizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var username = context.HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(username))
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }
            base.OnActionExecuting(context);
        }
    }
}
