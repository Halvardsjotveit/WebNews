using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using WebNews.Models.Pages;

namespace WebNews.Models.ViewModels
{
    public class ListPageViewModel : BasePage
    {
        public List<BasePage> ChildPages { get; set; }

        [Display(
            Name = "Main body",
            Description =
                "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual XhtmlString MainBody { get; set; }
    }
}