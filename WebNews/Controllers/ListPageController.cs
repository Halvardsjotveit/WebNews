using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using WebNews.Models.Pages;
using WebNews.Models.ViewModels;

namespace WebNews.Controllers
{
    public class ListPageController : PageController<ListPage>
    {
        public ActionResult Index(ListPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var model = new ListPageViewModel();
            model.ChildPages = new List<BasePage>();

            GetSubPageHeaders(model.ChildPages, currentPage);

            model.Header = currentPage.PageName;
            model.IntroText = currentPage.IntroText;
            model.MainBody = currentPage.MainBody;

            return View(model);
        }


        public void GetSubPageHeaders(List<BasePage> list, BasePage currentPage)
        {
            var serviceLocator = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>();
            var children = serviceLocator.GetChildren<BasePage>(currentPage.ContentLink).ToList();

            foreach (var child in children)
            {
                GetSubPageHeaders(list, child);
                list.Add(child);
            }


            
        }

    }
}