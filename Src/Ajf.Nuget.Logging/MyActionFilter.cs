﻿//using System.Linq;
//using System.Security.Claims;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;
//using Serilog;

//namespace Ajf.Nuget.Logging
//{
//    public class ApiLoggingFilterAttribute : ActionFilterAttribute
//    {
//        private readonly string[] _whitelist = {"given_name", "email", "family_name", "role", "sub"};

//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            var info = actionContext.RequestContext.Url.Request.RequestUri.ToString();
//            if (actionContext.RequestContext.Principal != null)
//                if (actionContext.RequestContext.Principal.Identity.IsAuthenticated)
//                {
//                    var claimsIdentity = actionContext.RequestContext.Principal.Identity as ClaimsIdentity;
//                    if (claimsIdentity != null)
//                        foreach (var claimsIdentityClaim in claimsIdentity.Claims)
//                            if (_whitelist.Contains(claimsIdentityClaim.Type))
//                                info += $";{claimsIdentityClaim.Type}={claimsIdentityClaim.Value}";
//                }

//            Log.Logger.Debug("Request: " + info);
//            base.OnActionExecuting(actionContext);
//        }
//    }
//}