using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace WebNews.Models.Blocks
{
    [ContentType(DisplayName = "ImageBlock", GUID = "729ec0db-e88e-45fd-9c80-1778a0b43055", Description = "")]
    public class ImageBlock : BlockData
    {
        [Display(
                GroupName = SystemTabNames.Content,
                Order = 400)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BlockImage { get; set; }
    }
}