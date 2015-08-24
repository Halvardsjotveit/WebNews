using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace WebNews.Models.Blocks
{
    [ContentType(DisplayName = "MiniTextBlock", GUID = "c43fd115-f899-4903-b4f9-bf86fda7b9c1", Description = "")]
    public class MiniTextBlock : BlockData
    {
        
                [CultureSpecific]
                [Display(
                    Name = "MiniText",
                    Description = "Small text without header",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual String Body { get; set; }
         
    }
}