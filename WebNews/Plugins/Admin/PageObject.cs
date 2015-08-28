using System.Collections.Generic;

namespace WebNews.Plugins.Admin
{
    public class PageObject
    {
        public int Type { get; set; }
        public string PageName { get; set; }
        public string IntroText { get; set; }
        public string MainBodyText { get; set; }
        public List<PageObject> Children { get; set; }

        public PageObject()
        {

        }

    }
}