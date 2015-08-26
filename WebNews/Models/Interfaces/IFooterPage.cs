using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;

namespace WebNews.Models.Interfaces
{
    public interface IFooterPage
    {
        XhtmlString EditableFooterText { get; set; }
    }
}