using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RepartidorOnline.UI.Filters
{
    public class ValidModelFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isModelValid = filterContext.Controller.ViewData.ModelState.IsValid;

            if (!isModelValid)
            {
                var errors = new StringBuilder();

                foreach (ModelState modelState in filterContext.Controller.ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors.AppendLine(error.ErrorMessage);
                    }
                }

                filterContext.HttpContext.Response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();

                filterContext.Result = new ContentResult() { Content = errors.ToString() };
            }

            base.OnActionExecuting(filterContext);
        }
    }
}