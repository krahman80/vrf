using POSB.VRF.Data;
using POSB.VRF.Domain.Helpers;
using POSB.VRF.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages.Razor;
using CaptchaMvc.Models;
using CaptchaMvc.HtmlHelpers;
using System.IO;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace POSB.VRF.Webapps.Controllers 
{
    [Authorize]
    public class VRFController : BaseController
    {
        
        private UnitOfWork unitOfWork = new UnitOfWork(new VRFContext());

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GenerateVRF()
        {
            var model = new VisitorRequestForm();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult GenerateVRF(VisitorRequestForm VisitorRequestForm, IEnumerable<HttpPostedFileBase> files)
        {
            //if (this.IsCaptchaValid("") && ModelState.IsValid)
            if (this.IsCaptchaValid(""))
            {

                var filename = "";
                //VisitorRequestForm.VisitorIDUpload = "test.jpg";
                if(files != null) {
                    foreach (var file in files)
                    {
                        filename = Path.GetFileName(file.FileName);
                        filename = string.Format(@"{0}.{1}", DateTime.Now.Ticks, filename.Split('.')[1]).ToLower();
                        var physicalPath = Path.Combine(Server.MapPath("~/UploadedFiles/VisitorFileAttachment"), filename);

                        file.SaveAs(physicalPath);
                    }
                }

                VisitorRequestForm.VisitorIDUpload = filename;

                
                Mapper(VisitorRequestForm);
                VisitorRequestForm.CreatedBy = VisitorRequestForm.VisitorName;
                VisitorRequestForm.ModifiedBy = VisitorRequestForm.VisitorName;
                try
                {
                    unitOfWork.VisitorRequestForms.Add(VisitorRequestForm);
                    unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    GeneralErrorMessage.Add(ex.InnerException.Message.ToString());
                }

                return RedirectToAction("Index","Home");   
            }
            GeneralErrorMessage.Add("Invalid captcha");
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            //var model = new VisitorRequestForm();
            return View();
        }

        [Authorize]
        public ActionResult VRF_Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = unitOfWork.VisitorRequestForms.GetAll();
            return Json(result.ToDataSourceResult(request));
        }

    }
}