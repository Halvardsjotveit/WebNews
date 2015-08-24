using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace WebNews.Models.Pages
{
    [ContentType(DisplayName = "HomePage", GUID = "A6872269-0173-4489-8640-190A564B65CB", Description = "")]
    public class HomePage : BasePage
    {
        
                [Display(
                    Name = "Main ContentArea",
                    Description = "Contentarea for information",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual ContentArea MainContentArea { get; set; }
         
    }
}