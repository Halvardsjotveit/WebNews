using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebNews.Business.Rendring
{
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            var viewLocations = new[] {
            "~/Views/Pages/{1}/{0}.cshtml",
            "~/Views/{1}/{0}.cshtml",
            "~/Views/Blocks/{0}/index.cshtml"
        };

            this.PartialViewLocationFormats = viewLocations;
            this.ViewLocationFormats = viewLocations;
        }
    }
}