using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using EPiServer.Web;

namespace WebNews.Models.Pages.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = UiHint)]
    public class CoordinatesEditorDescriptor : EditorDescriptor
    {
        public const string UiHint = "CoordinatesEditorDescriptor";

        public CoordinatesEditorDescriptor()
        {
            ClientEditingClass = "tedgustaf.googlemaps.Editor";
        }
    }
}