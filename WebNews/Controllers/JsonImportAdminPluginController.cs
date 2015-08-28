using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebNews.Controllers
{

    [EPiServer.PlugIn.GuiPlugIn(Area = EPiServer.PlugIn.PlugInArea.AdminMenu,
        Url = "~/Plugins/Admin/JsonImportTool.aspx",
        DisplayName = "Json Import Tool")]
    public class JsonImportAdminPluginController : Controller
    {
        // GET: JsonImportAdminPlugin
        public ActionResult Index()
        {
            return View();
        }
    }
}