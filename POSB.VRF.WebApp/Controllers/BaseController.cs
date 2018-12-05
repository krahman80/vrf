using POSB.VRF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace POSB.VRF.Webapps.Controllers
{
    public abstract class BaseController : Controller
    {

        protected string PasswordHash
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["PasswordHash"].ToString();
            }
        }
        
        #region session data

        protected string Role
        {
            get
            {
                if (Session["Role"] == null)
                {
                    return string.Empty;
                }
                return Session["Role"].ToString();
            }
            set
            {
                Session["Role"] = value;
            }
        }

        protected string UserLogin
        {
            get
            {
                if (Session["UserLogin"] == null)
                {
                    return string.Empty;
                }
                return Session["UserLogin"].ToString();
            }
            set
            {
                Session["UserLogin"] = value;
            }
        }

        protected string FullName
        {
            get
            {
                if (Session["FullName"] == null)
                {
                    return string.Empty;
                }
                return Session["FullName"].ToString();
            }
            set
            {
                Session["FullName"] = value;
            }
        }

        protected string Title
        {
            get
            {
                if (Session["Title"] == null)
                {
                    return string.Empty;
                }
                return Session["Title"].ToString();
            }
            set
            {
                Session["Title"] = value;
            }
        }

        protected bool IsLoginValid
        {
            get
            {
                if (Session["IsLoginValid"] == null)
                {
                    Session["IsLoginValid"] = false;
                }
                return bool.Parse(Session["IsLoginValid"].ToString());
            }
            set
            {
                Session["IsLoginValid"] = value;
            }
        }

        protected List<string> GeneralErrorMessage
        {
            get
            {
                try
                {
                    List<string> obj = Session["GeneralErrorMessage"] as List<string>;
                    if (obj == null || obj.Count == 0)
                    {
                        Session["GeneralErrorMessage"] = obj = new List<string>();
                    }
                    return (List<string>)obj;
                }
                catch (NullReferenceException)
                {
                    Session["GeneralErrorMessage"] = null;
                }
                return new List<string>();
            }
            set
            {
                Session["GeneralErrorMessage"] = value;
            }
        }
        /*
        private bool IsUserAuthenticated(HttpContextBase context)
        {
            return context.User != null && context.User.Identity != null && context.User.Identity.IsAuthenticated;
        }

        public String ControllerName
        {
            get
            {
                return RouteData.Values["Controller"].ToString();
            }
        }

        public List<Permission> ListOfPermission
        {
            get
            {
                try
                {
                    object obj = Session["ListOfPermission"];
                    if (obj == null)
                    {
                        Session["ListOfPermission"] = obj = new List<Permission>();
                    }
                    return (List<Permission>)obj;
                }
                catch (NullReferenceException)
                {
                    Session["ListOfPermission"] = new List<Permission>();
                }
                return new List<Permission>();
            }
            set
            {
                Session["ListOfPermission"] = value;
            }
        }

        protected void SetBag(string actionName)
        {
            ViewBag.UserViewModel = this.User;
            ViewBag.RoleMapping = this.ListOfPermission.Where(x => x.ControllerMethod.Split('-')[0].Equals(this.ControllerName.ToLower()) && x.ControllerMethod.Split('-')[1].Equals(actionName.ToLower())).FirstOrDefault(); ;
        }
        */
        #endregion

        #region Method
        public T Mapper<T>(T obj) where T : IModel
        {
            if (obj == null)
            {
                throw new Exception("BaseController : MapperModel");
            }
            if (obj.Id <= 0)
            {
                obj.IsActive = true;
                obj.CreatedBy = User.Identity.Name;
                obj.CreatedDate = DateTime.Now;
                obj.ModifiedDate = DateTime.Now;
                obj.ModifiedBy = User.Identity.Name;
            }
            else
            {
                obj.ModifiedBy = User.Identity.Name;
                obj.ModifiedDate = DateTime.Now;
            }
            
            return obj;
        }

        #endregion

        #region Session Helper    
        /*
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!IsExeceptionController(filterContext))
            {
                CheckSession(filterContext);
            }
            SetBag(filterContext.ActionDescriptor.ActionName);
        }

        private bool IsExeceptionController(ActionExecutingContext filterContext)
        {
            var actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            if (
                (!controllerName.Equals("Home", StringComparison.CurrentCultureIgnoreCase) && !actionName.Equals("Login", StringComparison.CurrentCultureIgnoreCase)) 
               )
            {
                return false;
            }
            return true;
        }

        private void CheckSession(ActionExecutingContext filterContext)
        {
            HttpContext context = System.Web.HttpContext.Current;
            if (context.Session != null)
            {
                if (context.Session.IsNewSession)
                {
                    string sessionCookie = context.Request.Headers["Cookie"];
                    if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        FormsAuthentication.SignOut();
                        string redirectTo = "~/Home/Login";
                        if (!string.IsNullOrEmpty(context.Request.RawUrl))
                        {
                            redirectTo = string.Format("~/Home/Login?ReturnUrl={0}", HttpUtility.UrlEncode(context.Request.RawUrl));
                            filterContext.Result = new RedirectResult(redirectTo);
                            return;
                        }
                    }
                }
                else if (!IsUserAuthenticated(base.HttpContext))
                {
                    FormsAuthentication.SignOut();
                    string redirectTo = "~/Home/Login";
                    if (!string.IsNullOrEmpty(context.Request.RawUrl))
                    {
                        redirectTo = string.Format("~/Home/Login?ReturnUrl={0}", HttpUtility.UrlEncode(context.Request.RawUrl));
                        filterContext.Result = new RedirectResult(redirectTo);
                        return;
                    }
                }
            }
            CheckAuthority(filterContext);
        }

        private void CheckAuthority(ActionExecutingContext filterContext)
        {

            string actionName = filterContext.ActionDescriptor.ActionName;
            var httpMethod = filterContext.HttpContext.Request.HttpMethod;
            if (!filterContext.HttpContext.Request.IsAjaxRequest() && !this.ControllerName.Equals("Home", StringComparison.CurrentCultureIgnoreCase))
            {
                if (!httpMethod.Equals("POST", StringComparison.CurrentCultureIgnoreCase))
                {
                    var Permission = ListOfPermission.Where(x => x.ControllerMethod.Split('-')[0].Equals(this.ControllerName.ToLower()) && x.ControllerMethod.Split('-')[1].Equals(actionName.ToLower())).FirstOrDefault();

                    if (Permission == null)
                    {
                        filterContext.Result = new RedirectResult("~/Home/AccessDenied");
                    }
                }
            }
        }
        */
        #endregion

    }
}