using System;
using System.Web.Mvc;
using System.Web.Optimization;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Web.WebControls;
using WebNews.App_Start;
using WebNews.Business.Rendring;
using WebNews.Models.Pages;
using WebNews.Utils.Extensions;

namespace WebNews
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ViewEngines.Engines.Add(new CustomViewEngine());
            BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DataFactory.Instance.PublishedContent += OnPublishedContent;
            DataFactory.Instance.PublishingContent += OnPublishingContent;
            //DataFactory.Instance.SavedContent += OnSavedContent;
            //DataFactory.Instance.SavingContent += OnSavingContent;
            //DataFactory.Instance.CreatingContent += OnCreatingContent;
            //DataFactory.Instance.CreatedContent += OnCreatedContent;
            ////DataFactory.Instance.mo += OnCreatedContent;

            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }

        private void OnCreatedContent(object sender, ContentEventArgs e)
        {
            LogInfo("CreatedContent", e);
        }

        private void OnCreatingContent(object sender, ContentEventArgs e)
        {
            LogInfo("CreatingContent", e);
        }

        private void OnSavingContent(object sender, ContentEventArgs e)
        {
            LogInfo("SavingContent", e);
        }

        private void OnSavedContent(object sender, ContentEventArgs e)
        {
            LogInfo("SavedContent", e);
        }

        private void OnPublishedContent(object sender, ContentEventArgs e)
        {

            LogInfo("PublishedContent", e);
        }

        private void SetEventPageCoordinatesInDB(ContentEventArgs e)
        {
            var originalPage = DataFactory.Instance.GetPage(e.ContentLink.ToPageReference());
            var page = originalPage.CreateWritableClone() as EventPage;

            if (page != null)
            {
                if (page.Coordinates.IsNotNullOrEmpty())
                {

                    page.PageLatitude = double.Parse(page.Coordinates.Split(',')[0]);
                    page.PageLongitude = double.Parse(page.Coordinates.Split(',')[1]);
                }
                DataFactory.Instance.Save(page, SaveAction.Save);
            }
        }

        private void OnPublishingContent(object sender, ContentEventArgs e)
        {
            SetEventPageCoordinatesInDB(e);
            LogInfo("PublishingContent", e);
        }




        private static void LogInfo(string type, ContentEventArgs e)
        {
            log4net.ILog log =
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            var msg = string.Format("EventType: {0}, PageId: {1}, Name: {2}", type, e.ContentLink.ID, e.Content.Name);

            log.Error(msg);
            //log.Error($"Publish Event: //n Page Name {e.Page.PageName.ToString()} //n Page ID: {e.PageLink.ID.ToString()}");
        }
    }
}