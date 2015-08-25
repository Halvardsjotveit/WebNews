using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using WebNews.Models.Pages;
using WebNews.Models.ViewModels;
using WebNews.Utils;

namespace WebNews.Controllers
{
    public class ListPageController : PageController<ListPage>
    {
        public ActionResult Index(ListPage currentPage)
        {
            var model = new ListPageViewModel(currentPage);

            var serviceLocator = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>();
            var children = serviceLocator.GetChildren<BasePage>(currentPage.ContentLink).ToList();
            model.ChildPages = children.FilterForVisitorAndMenu().ToList();

            return View(model);
        }


    }
}