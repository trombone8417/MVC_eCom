using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_eCom.Web.Controllers
{
    public class SharedController : Controller
    {
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];
                //圖片名稱重新命名(唯一識別項)
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                //上傳圖片位置
                var path = Path.Combine(Server.MapPath("~/content/images/"), fileName);
                file.SaveAs(path);
                result.Data = new { Success = true, ImageURL = string.Format("/content/images/{0}",fileName )};
            }
            catch (Exception ex)
            {

                result.Data = new { Success = false, Message= ex.Message};
            }

            return result;
        }
    }
}