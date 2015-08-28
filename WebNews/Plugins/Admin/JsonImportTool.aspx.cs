using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using Newtonsoft.Json;
using WebNews.Models.Pages;
using WebNews.Utils;
using WebNews.Utils.Extensions;

namespace WebNews.Plugins.Admin
{
    public partial class JsonImportTool : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {

        }

        public void ImportJsonObjects(object sender, EventArgs eventArgs)
        {

            if (string.IsNullOrEmpty(IdBox.Text)) return;

            var parentPageId = int.Parse(IdBox.Text);

            var pageObjects = GetPageObjects();

            CreatePageStructureUnderParent(new PageReference(parentPageId), pageObjects);


        }

        private void CreatePageStructureUnderParent(PageReference parent, List<PageObject> pageObjects)
        {

            var contentRepo = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IContentRepository>();

            foreach (var pageObj in pageObjects)
            {
                PageReference newParentReference = CreatePageFromJson(pageObj, parent, contentRepo);
                if (pageObj.Children != null)
                {
                    CreatePageStructureUnderParent(newParentReference, pageObj.Children);
                }

            }
        }

        private PageReference CreatePageFromJson(PageObject pageObject, PageReference parent, IContentRepository contentRepo)
        {
            BasePage newPage;
            switch (pageObject.Type)
            {
                case 0:
                    ArticlePage aPage = contentRepo.GetDefault<ArticlePage>(parent);
                    aPage.MainBody = pageObject.MainBodyText;
                    newPage = aPage;
                    break;
                case 1:
                    newPage = contentRepo.GetDefault<FolderPage>(parent);
                    break;
                case 2:
                    ListPage lPage = contentRepo.GetDefault<ListPage>(parent);
                    lPage.MainBody = pageObject.MainBodyText;
                    newPage = lPage;
                    break;
                case 3:
                    newPage = contentRepo.GetDefault<PersonPage>(parent);
                    break;
                case 4:
                    newPage = contentRepo.GetDefault<PortalPage>(parent);
                    break;
                default:
                    newPage = contentRepo.GetDefault<ArticlePage>(parent);
                    break;
            }

            newPage.PageName = pageObject.PageName;
            newPage.IntroText = pageObject.IntroText;
            contentRepo.Save(newPage, SaveAction.Publish);
            return newPage.PageLink;
        }

        private List<PageObject> GetPageObjects()
        {
            string jsonText = System.IO.File.ReadAllText(Constants.FileLocations.JsonFileLocation);
            return JsonConvert.DeserializeObject<List<PageObject>>(jsonText);
        }

    }
}