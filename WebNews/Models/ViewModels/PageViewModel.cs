using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.WebPages;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using NuGet;
using WebNews.Models.ViewModels;
using WebNews.Models.Pages;
using WebNews.Utils;


namespace WebNews.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : BasePage
    {


        public XhtmlString FooterText { get; set; }
        public T CurrentPage { get; private set; }
        public List<PageData> MenuPages { get; set; }
        public IContentLoader ServiceLocator { get; set; }
        public List<PageData> BreadCrumbs { get; set; }


        public PageViewModel(T currentPage)
        {
            ServiceLocator = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentLoader>();
            CurrentPage = currentPage;

            FooterText = GetFooterText();
            MenuPages = GetChildrenses();
            BreadCrumbs = currentPage.GetParentPagesOfType<BasePage>()
                                     .FilterForVisitorAndMenu()
                                     .ToList();


        }

        private XhtmlString GetFooterText()
        {

            if (CurrentPage is PortalPage)
            {
                var currentPortalPage = CurrentPage as PortalPage;
                if (currentPortalPage.CustomFooterText != null)
                    return currentPortalPage.CustomFooterText;
            }

            var parents = CurrentPage.GetParentPagesOfType<PortalPage>()
                                     .FilterForVisitorAndMenu()
                                     .Cast<PortalPage>()
                                     .ToList();


            parents.Reverse();

            foreach (var portalPage in parents)
            {
                if (portalPage.CustomFooterText != null)
                    return portalPage.CustomFooterText;
            }

            var startPage = ServiceLocator.Get<HomePage>(ContentReference.StartPage);
            return startPage.FooterText;
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