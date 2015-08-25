using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace WebNews.Models.Pages
{
    [ContentType(DisplayName = "ArticlePage", GUID = "e8110a52-bc83-429a-8470-b9b8c573d963", Description = "")]
    public class ArticlePage : BaseEditorialPage
    {}
}