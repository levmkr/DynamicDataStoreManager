using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using DynamicDataStoreManager.Web.AdminTools.DynamicDataStoreManager.Models;
using DynamicDataStoreManager.Web.AdminTools.DynamicDataStoreManager.Services;
using EPiServer.Data;
using EPiServer.PlugIn;

namespace DynamicDataStoreManager.Web.AdminTools.DynamicDataStoreManager.Controllers
{
    [GuiPlugIn(
        Area = PlugInArea.AdminMenu,
        Url = "/custom-plugins/dds-plugin",
        DisplayName = "Dynamic Data Store Manager")]
    [Authorize(Roles = "CmsAdmins, Administrators")]
    public class DdsManagerController : Controller
    {
        private readonly IDynamicDataStoreService _dataStoreService;

        public DdsManagerController(IDynamicDataStoreService dataStoreService)
        {
            _dataStoreService = dataStoreService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View("~/AdminTools/DynamicDataStoreManager/Views/ddsplugin.cshtml", null);
        }

        [HttpGet]
        [Authorize]
        public JsonResult GetStores()
        {
            var storesAndMappings = _dataStoreService.GetAllStoresNamesAndMappings().Where(s => s.TableName == "tblBigTable");
            var serialized = new List<StoresandMappings>();

            foreach (var storesAndMapping in storesAndMappings)
            {
                var serializedStoresandMappings = new StoresandMappings
                {
                    Name = storesAndMapping.StoreName,
                };

                serializedStoresandMappings.Mappings.AddRange(storesAndMapping.MappingNames);
                serialized.Add(serializedStoresandMappings);
            }

            return Json(serialized, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public JsonResult GetStoreData(string storeName)
        {
            var dynamicDataStore = _dataStoreService.GetStore(storeName);
            var storeItems = new List<object>();
            if (dynamicDataStore != null)
            {
                storeItems = dynamicDataStore.Items().ToList();
            }

            return Json(storeItems, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteStoreItem(string externalId, string storeId, string storeName)
        {
            Identity id;
            if (Identity.TryParse($"{storeId}:{externalId}", out id))
            {
                _dataStoreService.DeleteItem(id, storeName);

                // return success
                return null;
            }
            // return 404 store not found
            return null;
        }
    }
}