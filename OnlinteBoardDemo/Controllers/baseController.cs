using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlinteBoardDemo.Controllers
{
    public class baseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            String Errormsg = String.Empty;


            Exception unhandledException = filterContext.Exception;


            Exception httpException = unhandledException as Exception;

            Errormsg = "{3}發生例外網頁:{0}錯誤訊息:{1}堆疊內容:{2}";

            if (httpException != null && !httpException.GetType().IsAssignableFrom(typeof(HttpException)))
            {

                Errormsg = String.Format(Errormsg, Request.Path + Environment.NewLine,

                    unhandledException.GetBaseException().Message + Environment.NewLine,
                    unhandledException.StackTrace + Environment.NewLine,
                    DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + Environment.NewLine);
                //寫入文字檔

                System.IO.File.AppendAllText(Server.MapPath("~/baseController.txt"), Errormsg);



                //寫入事件撿視器  


               

                Server.ClearError();
            }
            base.OnException(filterContext);

            if (filterContext.ExceptionHandled)
            {
                return;
            }
            filterContext.Result = new ViewResult
            {
                ViewName = "Error"
            };
            filterContext.ExceptionHandled = true;
        }
    }
}