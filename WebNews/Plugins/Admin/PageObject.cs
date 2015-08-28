using System.Collections.Generic;
using EPiServer.Core;

namespace WebNews.Plugins.Admin
{
    public class PageObject
    {
        public int Type { get; set; }
        public string PageName { get; set; }
        public string IntroText { get; set; }
        public XhtmlString MainBodyText { get; set; }
        public List<PageObject> Children { get; set; }

        public PageObject()
        {

        }

    }
}