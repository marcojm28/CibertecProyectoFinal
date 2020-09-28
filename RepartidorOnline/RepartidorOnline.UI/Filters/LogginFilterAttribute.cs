using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace RepartidorOnline.UI.Filters
{
    public class LogginFilterAttribute : ActionFilterAttribute
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var message = $"Iniciando la ejecución del controlador:" +
            $" {filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}" +
            $", Action: {filterContext.ActionDescriptor.ActionName}" +
            $",Hora de inicio: {DateTime.Now}";

            log.Info(message);

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var message = $"Finalizando la ejecución del controlador:" +
            $" {filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}" +
            $", Action: {filterContext.ActionDescriptor.ActionName}" +
            $",Hora de fin: {DateTime.Now}";

            log.Info(message);

            base.OnActionExecuted(filterContext);
        }
    }
}