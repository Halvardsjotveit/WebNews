using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace WebNews.Models.Blocks
{
    [ContentType(DisplayName = "TextBlock", GUID = "f3cfc2ff-d470-417a-aa03-dd607abdd2f7", Description = "")]
    public class TextBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Header",
            Description = "Textblock header",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual String Header { get; set; }

        [CultureSpecific]
        [Display(
                    Name = "Body",
                    Description = "Textblock body",
                    GroupName = SystemTabNames.Content,
                    Order = 2)]
        public virtual String Body { get; set; }

    }
}