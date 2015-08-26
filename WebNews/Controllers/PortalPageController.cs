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
    public class PortalPageController : PageController<PortalPage>
    {
        public ActionResult Index(PortalPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);

            var editingHints = ViewData.GetEditHints<PageViewModel<PortalPage>, PortalPage>();
            editingHints.AddConnection(viewModel => viewModel.FooterText, page => page.EditableFooterText);
            return View(model);
        }
    }
}