using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace WebNews.Models.Pages
{
    [ContentType(DisplayName = "FolderPage", GUID = "1cb6fbb4-992a-46bd-9fd9-4ae036fbce6e", Description = "",
        AvailableInEditMode = true)]
    public class FolderPage : BasePage
    {
        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            this.VisibleInMenu = false;
        }
    }
}