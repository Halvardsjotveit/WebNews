using EPiServer.Shell;
using WebNews.Models.Pages;

namespace WebNews.Business.UIDescriptors
{
    [UIDescriptorRegistration]
    public class FolderPageUiDescriptor : UIDescriptor<FolderPage>
    {
        public FolderPageUiDescriptor()
            : base(ContentTypeCssClassNames.Container)
        {
            DefaultView = CmsViewNames.AllPropertiesView;
        }
    }
}