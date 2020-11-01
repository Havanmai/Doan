using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace Doan1
{
    public class HasCredentialAttribute: AuthorizeAttribute
    {
        public string IdRole { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (Common.AccountLogin)HttpContext.Current.Session[Common.CommonConstant.USER_SESSION];
            if (session == null)
            {
                return false;
            }

            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.Username); // Call another method to get rights of the user from DB

            if (privilegeLevels.Contains(this.IdRole) || session.IdGroup == CommonConstant.ADMIN_GROUP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/_401.cshtml"
            };
        }
        private List<string> GetCredentialByLoggedInUser(string userName)
        {
            var credentials = (List<string>)HttpContext.Current.Session[Common.CommonConstant.SESSION_CREDENTIALS];
            return credentials;
        }
    }
}