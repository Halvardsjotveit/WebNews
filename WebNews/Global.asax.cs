using System;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
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

            DataFactory.Instance.PublishedContent += OnPublishedContent;
            //DataFactory.Instance.PublishingContent += OnPublishedContent;
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
            SetEventPageCoordinatesInDB(e);
            LogInfo("PublishedContent", e);
        }

        private void SetEventPageCoordinatesInDB(ContentEventArgs e)
        {
            var page = e.Content as EventPage;
            if (page != null)
            {
                if (page.Coordinates.IsNotNullOrEmpty())
                {
                    page.Latitude = double.Parse(page.Coordinates.Split(',')[0]);
                    page.Longitude = double.Parse(page.Coordinates.Split(',')[1]);
                }
            }
        }

        private void OnPublishingContent(object sender, ContentEventArgs e)
        {

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