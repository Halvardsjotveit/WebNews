using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.Filters;
using WebNews.Models.Pages;

namespace WebNews.Utils
{
    public static class PageDataExtensions
    {
        /// <summary>
        /// Removes pages that visitor does not have access to view, and pages that should not be displayed in menu
        /// </summary>
        /// <param name="pageList"></param>
        /// <returns></returns>
        public static IEnumerable<PageData> FilterForVisitorAndMenu(this IEnumerable<PageData> pageList)
        {
            if (pageList == null)
                return new List<PageData>();

            var filterdPages =
                pageList.Select(page => page)
                    .Where(page => page.VisibleInMenu)
                    .Where(page => !(page is FolderPage));

            filterdPages = FilterForVisitor.Filter(filterdPages)
                .Select(page => page)
                //.Where(page => page as PageData != null)
                .Cast<PageData>();

            return filterdPages;
        }

    }
}