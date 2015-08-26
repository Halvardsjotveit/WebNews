using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.WebPages;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using NuGet;
using WebNews.Models.Interfaces;
using WebNews.Models.ViewModels;
using WebNews.Models.Pages;
using WebNews.Utils;
using PageDataExtensions = WebNews.Utils.PageDataExtensions;


namespace WebNews.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : BasePage
    {


        public XhtmlString FooterText { get; set; }
        public T CurrentPage { get; private set; }
        public List<PageData> MenuPages { get; set; }
        public IContentLoader ServiceLocator { get; set; }
        public List<PageData> BreadCrumbs { get; set; }
        public bool IsPortalPageFooter { get; set; }
        public PortalPage PortalPageReference { get; set; }


        public PageViewModel(T currentPage)
        {
            ServiceLocator = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentLoader>();
            CurrentPage = currentPage;

            FooterText = GetFooterText(currentPage);
            MenuPages = GetChildrenses();
            BreadCrumbs = currentPage.GetParentPagesOfType<BasePage>()
                                     .FilterForVisitorAndMenu()
                                     .ToList();


        }

        private XhtmlString GetFooterText(T currentPage)
        {


            var currentIFooterPage = currentPage as IFooterPage;
            if (currentIFooterPage != null && currentIFooterPage.EditableFooterText != null)
                return currentIFooterPage.EditableFooterText;

            var footerPages = currentPage.GetParentPagesOfType<BasePage>(PageDataExtensions.ParentSortOrder.BottomUp)
                                         .Where(x => x is IFooterPage)
                                         .FilterForVisitorAndMenu()
                                         .Cast<IFooterPage>();

            var parentFooterPage = footerPages.FirstOrDefault(page => page.EditableFooterText != null);

            return (parentFooterPage != null)
                ? parentFooterPage.EditableFooterText
                : null;
        }


        private List<PageData> GetChildrenses()
        {
            var children = ServiceLocator.GetChildren<BasePage>(ContentReference.StartPage).ToList();

            return children.FilterForVisitorAndMenu().ToList();
        }

    }

    public static class PageViewModel
    {

        public static PageViewModel<T> Create<T>(T page) where T : BasePage
        {
            return new PageViewModel<T>(page);
        }
    }

}