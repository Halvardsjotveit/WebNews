using EPiServer.Core;
using WebNews.Models.Pages;

namespace WebNews.Models.ViewModels
{
    /// <summary>
    /// Defines common characteristics for view models for pages, including properties used by layout files.
    /// </summary>
    /// <remarks>
    /// Views which should handle several page types (T) can use this interface as model type rather than the
    /// concrete PageViewModel class, utilizing the that this interface is covariant.
    /// </remarks>
    public interface IPageViewModel<out T> where T : BasePage
    {
        T CurrentPage { get; }
        XhtmlString FooterText { get; set; }
    }
}