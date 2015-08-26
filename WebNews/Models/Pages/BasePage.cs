using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace WebNews.Models.Pages
{
    public class BasePage : PageData
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