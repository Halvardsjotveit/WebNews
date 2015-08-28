using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPiServer;
using EPiServer.Core;
using Newtonsoft.Json;
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

            var parentPage = DataFactory.Instance.GetPage(new PageReference(parentPageId));

            string jsonText = System.IO.File.ReadAllText(Constants.FileLocations.JsonFileLocation);

            PageObject pageObject = JsonConvert.DeserializeObject<PageObject>(jsonText);


        }

    }
}