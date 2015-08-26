using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using WebNews.Models.Pages;
using WebNews.Models.ViewModels;

namespace WebNews.Controllers
{
    public class HomePageController : PageController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            var editingHints = ViewData.GetEditHints<PageViewModel<PortalPage>, PortalPage>();
            editingHints.AddConnection(viewModel => viewModel.FooterText, page => page.EditableFooterText);
            return View(model);
        }
    }
}