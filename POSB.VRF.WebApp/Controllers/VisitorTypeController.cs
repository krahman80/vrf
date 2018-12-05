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

namespace POSB.VRF.Webapps.Controllers 
{
    [Authorize]
    public class VisitorTypeController : BaseController
    {
        
        private UnitOfWork unitOfWork = new UnitOfWork(new VRFContext());

        [AllowAnonymous]
        public JsonResult GetVisitorType()
        {
            var datas = unitOfWork.VisitorTypes.GetAll();
            return Json(datas, JsonRequestBehavior.AllowGet);
        }

    }
}