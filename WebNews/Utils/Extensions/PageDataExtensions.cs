using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
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

        public static List<PageData> GetParentPagesOfType<T>(this PageData currentPage) where T : PageData
        {
            var serviceLocator = ServiceLocator.Current.GetInstance<IContentLoader>();

            var parents = serviceLocator.GetAncestors(currentPage.ContentLink)
                                        .Cast<PageData>()
                                        .Where(x => x is T)
                                        .ToList();
            parents.Reverse();
            return parents;
        }

    }
}