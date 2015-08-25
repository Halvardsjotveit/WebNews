﻿using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace WebNews.Models.Pages
{
    [ContentType(DisplayName = "ListPage", GUID = "6e38c88d-036d-4b32-a2a0-ab60d2afa389", Description = "")]
    public class ListPage : BasePage
    {

        [CultureSpecific]
        [Display(
            Name = "Main body",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual XhtmlString MainBody { get; set; }

    }
}