using System.Collections.Generic;
using System.Linq;
using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace DynamicDataStoreManager.Web.AdminTools.DynamicDataStoreManager.Services
{
    public class DynamicDataStoreService : IDynamicDataStoreService
    {
        public DynamicDataStore GetOrCreateStore<T>() where T : IDynamicData
        {
            var type = typeof(T);
            var store = DynamicDataStoreFactory.Instance.GetStore(type) ?? DynamicDataStoreFactory.Instance.CreateStore(type);
            return store;
        }

        public DynamicDataStore GetStore<T>() where T : IDynamicData
        {
            var type = typeof(T);
            var store = DynamicDataStoreFactory.Instance.GetStore(type);
            return store;
        }

        public DynamicDataStore GetStore(string storeName)
        {
            var store = DynamicDataStoreFactory.Instance.GetStore(storeName);
            return store;
        }

        public void RemapStore<T>()
        {
            var type = typeof(T);
            var name = DynamicDataStoreFactory.Instance.GetStoreNameForType(type);
            var storeDef = StoreDefinition.Get(name);

            if (storeDef == null || storeDef.ValidateAgainstMappings(type, false)) return;

            storeDef.Remap(type);
            storeDef.CommitChanges();
        }

        public IOrderedQueryable<T> GetItems<T>() where T : IDynamicData
        {
            var store = GetStore<T>();
            return store?.Items<T>();
        }

        public bool SaveItem<T>(T item) where T : IDynamicData
        {
            var store = GetOrCreateStore<T>();
            var id = store.Save(item);
            return id != null;
        }

        public Identity SaveItemGetId<T>(T item) where T : IDynamicData
        {
            var store = GetOrCreateStore<T>();
            var id = store.Save(item);
            return id;
        }

        public void DeleteItem<T>(T item) where T : IDynamicData
        {
            var store = GetStore<T>();
            store?.Delete(item);
        }

        public void DeleteAll<T>() where T : IDynamicData
        {
            var store = GetStore<T>();
            store?.DeleteAll();
        }

        public void DeleteStore<T>(bool deleteObjects) where T : IDynamicData
        {
            var type = typeof(T);
            DynamicDataStoreFactory.Instance.DeleteStore(type, deleteObjects);
        }

        public void DeleteItem(Identity id, string storeName)
        {
            //var storeDefinitions = StoreDefinition.GetAll();
            //StoreDefinition store = storeDefinitions.FirstOrDefault(s => s.Id == id.StoreId);
            var store = DynamicDataStoreFactory.Instance.GetStore(storeName);
            store?.Delete(id);

            //if (store != null)
            //{
            //    DynamicDataStore ddsStore = DynamicDataStoreFactory.Instance.GetStore(store.StoreName);
            //    store.Delete(id);
            //}
        }

        public IEnumerable<StoreDefinition> GetAllStoresNamesAndMappings()
        {
            var storeDefinitions = StoreDefinition.GetAll();
            return storeDefinitions;
        }
    }
}