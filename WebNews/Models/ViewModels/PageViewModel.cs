using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using WebNews.Models.ViewModels;
using WebNews.Models.Pages;

namespace WebNews.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : BasePage 
    {

        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;

            var servicelocator = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentLoader>();
            var startPage = servicelocator.Get<HomePage>(ContentReference.StartPage);
            FooterText = startPage.FooterText;

        }

        public XhtmlString FooterText { get; set; }
        public T CurrentPage { get; private set; }

    }

    public static class PageViewModel
        {

            public static PageViewModel<T> Create<T>(T page) where T : BasePage
            {
                return new PageViewModel<T>(page);
            }
        }
    
}