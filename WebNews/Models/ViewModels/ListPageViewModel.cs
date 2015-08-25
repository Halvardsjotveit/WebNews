using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using WebNews.Models.Pages;

namespace WebNews.Models.ViewModels
{
    public class ListPageViewModel : PageViewModel<ListPage>
    {

        public ListPageViewModel(ListPage currentPage)
            : base (currentPage)
        { }
   
        public List<BasePage> ChildPages { get; set; }
    }
}