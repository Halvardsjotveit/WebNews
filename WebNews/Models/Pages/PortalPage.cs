using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace WebNews.Models.Pages
{
    [ContentType(DisplayName = "PortalPage", GUID = "314f4bea-f001-4dbc-84f1-01706a397a29", Description = "")]
    public class PortalPage : BasePage
    {

        [Display(
            Name = "Main ContentArea",
            Description = "Contentarea for information",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual ContentArea MainContentArea { get; set; }


        [Display(
            Name = "Custom Footer Text",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual XhtmlString CustomFooterText { get; set; }
    }
}