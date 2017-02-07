using System.Web.Mvc;
using DynamicDataStoreManager.Web.Models.Pages;
using DynamicDataStoreManager.Web.Models.ViewModels;
using EPiServer.Web.Mvc;

namespace DynamicDataStoreManager.Web.Controllers
{
    public class StartPageController : PageController<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            var viewModel = PageViewModel.Create(currentPage);
            return View(viewModel);
        }
    }
}