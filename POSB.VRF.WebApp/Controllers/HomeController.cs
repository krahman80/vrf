using POSB.VRF.Data;
using POSB.VRF.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages.Razor;

namespace POSB.VRF.Webapps.Controllers 
{
    [Authorize]
    public class HomeController : BaseController
    {
        
        private UnitOfWork unitOfWork = new UnitOfWork(new VRFContext());

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {

            var users = unitOfWork.Users.GetAll();
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            
            return View(users.ToList());
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return PartialView();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
            {
                return PartialView();
            }
            else
            {
                //FormsAuthentication.SetAuthCookie(username, true);  //comment when done
                //IsLoginValid = true;
                //return RedirectToAction("Index");
                string encryptedPassword = EncryptHelper.Encrypt(password, PasswordHash);

                var user = unitOfWork.Users.GetAll().Where(x => x.Login.Equals(username, StringComparison.CurrentCulture)).FirstOrDefault();
                if(user == null)
                {
                    GeneralErrorMessage.Add("Username not found");
                    return PartialView();
                }
                else if (!user.Password.Equals(encryptedPassword, StringComparison.CurrentCulture))
                {
                    GeneralErrorMessage.Add("Wrong password");
                    return PartialView();
                }
                else if (!user.IsActive)
                {
                    GeneralErrorMessage.Add("Username already disabled");
                    return PartialView();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(username, true);  //comment when done
                    UserLogin = user.Login;
                    FullName = user.FullName;
                    Title = user.Title;
                    IsLoginValid = true;
                    var role = unitOfWork.Roles.Get(user.RoleId);
                    Role = role.Name;

                    //return RedirectToAction("Index");
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index","VRF");
                    }
                }

                //GeneralErrorMessage.Add("Username not found");
                //return View();
            }

        }


        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            IsLoginValid = false;

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            return RedirectToAction("Login");
        }


        [HttpGet]
        [Authorize]
        public ActionResult Test()
        {
            //var users = unitOfWork.Users.GetUserWithRole(3);            
            return View();
        }
        

    }
}