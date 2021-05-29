using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.IO;
namespace Student_info_API.Filters
{
    public class CustomActionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
           
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            String data = actionContext.Request.RequestUri + "" + actionContext.ActionDescriptor.ActionName+" " +DateTime.Now.ToString();
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/log.txt"), data+"\n");
        }
    }
}