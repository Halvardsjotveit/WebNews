using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using WebNews.Models.Pages;
using WebNews.Models.ViewModels;
using System.Web.WebPages;

namespace WebNews.Controllers
{
    public class ArticlePageController : PageController<ArticlePage>
    {
        public ActionResult Index(ArticlePage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */


            //var servicelocator = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>();

            //var startpage = DataFactory.Instance.GetPage(PageReference.StartPage);

            //var model =  new PageViewModel();
            //model.FooterText = startpage.GetPropertyValue("FooterText");

            var model = PageViewModel.Create(currentPage);

            return View(model);
        }
    }
}