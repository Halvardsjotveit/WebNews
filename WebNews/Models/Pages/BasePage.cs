using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace WebNews.Models.Pages
{
    [ContentType(DisplayName = "BasePage", GUID = "e4e89d52-74a6-49b7-a03a-81aa42e5dd21", Description = "")]
    public abstract class BasePage : PageData
    {
        [Display(
        Name = "IntroText",
        GroupName = SystemTabNames.Content,
        Order = 2)]
        [UIHint(UIHint.LongString)]
        public virtual string IntroText { get; set; }


        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            this.VisibleInMenu = true; 
        }


    }
}