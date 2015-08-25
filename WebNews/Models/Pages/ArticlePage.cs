using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace WebNews.Models.Pages
{
    [ContentType(DisplayName = "ArticlePage", GUID = "e8110a52-bc83-429a-8470-b9b8c573d963", Description = "")]
    public class ArticlePage : BasePage
    {
        [Display(
        Name = "Main body",
        Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
        GroupName = SystemTabNames.Content,
        Order = 5)]
        public virtual XhtmlString MainBody { get; set; }
    }
}