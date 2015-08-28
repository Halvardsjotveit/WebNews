using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using WebNews.Models.Pages.EditorDescriptors;

namespace WebNews.Models.Pages
{
    [ContentType(DisplayName = "EventPAge", GUID = "ca04943f-b3bc-4523-b484-e99a117739c4", Description = "")]
    public class EventPage : BasePage
    {

        [Display(Name = "Event Description",
               GroupName = SystemTabNames.Content,
               Order = 3)]
        public virtual XhtmlString EventText { get; set; }

        [Required]
        [Display(Name = "Event Start Time",
                GroupName = SystemTabNames.Content,
                Order = 4)]
        public virtual DateTime StartTime { get; set; }

        [Display(Name = "Event End Time",
               GroupName = SystemTabNames.Content,
               Order = 5)]
        public virtual DateTime? EndTime { get; set; }


        [EditorDescriptor(EditorDescriptorType = typeof(CoordinatesEditorDescriptor))]
        public virtual string Coordinates { get; set; }


        [AllowedTypes(new[] { typeof(PersonPage) })]
        [Display(Name = "Event Contact Person",
               GroupName = SystemTabNames.Content,
               Order = 7)]
        public virtual ContentReference EventPerson { get; set; }

    }
}