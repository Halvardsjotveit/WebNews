using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace WebNews.Models.Blocks
{
    [ContentType(DisplayName = "ButtonBlock", GUID = "31dff3e2-3ec8-4335-b5b8-24a78b13dee0", Description = "")]
    public class ButtonBlock : BlockData
    {
        [Display(
     GroupName = SystemTabNames.Content,
     Order = 3
     )]
        [CultureSpecific]
        [Required]
        public virtual string ButtonText { get; set; }

        //The link must be required as an anchor tag requires an href in order to be valid and focusable
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 4
            )]
        [CultureSpecific]
        [Required]
        public virtual Url ButtonLink { get; set; }
    }
}