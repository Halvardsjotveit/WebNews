﻿using System.Collections.Generic;
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

            var model = new ListPageViewModel(currentPage);

            // Finding the lost childrenses
            var serviceLocator = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>();
            model.ChildPages = serviceLocator.GetChildren<BasePage>(currentPage.ContentLink).ToList();

            return View(model);
        }

    }
}