using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace WebNews.Models.Blocks
{
    [ContentType(DisplayName = "ClientBlock", GUID = "2d2d93fc-3b42-4b8b-a35e-cd5eaf88608b", Description = "")]
    public class ClientLogoBlock : BlockData
    {
        [Display(
                GroupName = SystemTabNames.Content,
                Order = 1)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ClientLogoImage { get; set; }

    }
}