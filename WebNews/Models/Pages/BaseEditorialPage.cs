using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace WebNews.Models.Pages
{
    [ContentType(DisplayName = "BaseEditorialPage", GUID = "6a74c9e8-5e7b-4584-acf4-0e875c9f0191", Description = "")]
    public class BaseEditorialPage : BasePage
    {
        [Display(
            Name = "Main body",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual XhtmlString MainBody { get; set; }
    }
}