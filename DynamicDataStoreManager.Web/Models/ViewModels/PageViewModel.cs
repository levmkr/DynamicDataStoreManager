using EPiServer.Core;

namespace DynamicDataStoreManager.Web.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : PageData
    {
        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }
        public T CurrentPage { get; }
    }

    public static class PageViewModel
    {
        public static PageViewModel<T> Create<T>(T page) where T : PageData
        {
            return new PageViewModel<T>(page);
        }
    }
}