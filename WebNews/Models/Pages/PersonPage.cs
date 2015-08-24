using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.UI.Admin;

namespace WebNews.Models.Pages
{
    [ContentType(DisplayName = "PersonPage", GUID = "079dcc2b-214f-41ee-be64-d14b7230439c", Description = "")]
    public class PersonPage : BasePage
    {


        [Display(
            Name = "First Name",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual string FirstName { get; set; }



        [Display(
            Name = "Last Name",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual string LastName { get; set; }


        [Display(
            Name = "Street",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual string Street { get; set; }

        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Must be a valid 4 digit postal code")]
        [Display(
            Name = "PostalCode",
            GroupName = SystemTabNames.Content,
            Order = 6)]
        public virtual string PostalCode { get; set; }


        [Display(
            Name = "City",
            GroupName = SystemTabNames.Content,
            Order = 7)]
        public virtual string City { get; set; }


        [RegularExpression(@"^([A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,9})$",
            ErrorMessage = "Must be valid email address")]
        [Display(
            Name = "Email",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        public virtual string Email { get; set; }


        [Display(
    Name = "Main body",
    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
    GroupName = SystemTabNames.Content,
    Order = 5)]
        public virtual XhtmlString MainBody { get; set; }
    }
}