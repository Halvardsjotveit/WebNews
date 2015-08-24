using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace WebNews.Models.Blocks
{
    [ContentType(DisplayName = "HalvardBlock", GUID = "", Description = "")]
    public class TextOverlayImageBlock : BlockData
    {

        [Display(
                GroupName = SystemTabNames.Content,
                Order = 400)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BlockImage { get; set; }

        public virtual string ImageOverlayText { get; set; }
        public virtual string UnderImageText { get; set; }


    }
}