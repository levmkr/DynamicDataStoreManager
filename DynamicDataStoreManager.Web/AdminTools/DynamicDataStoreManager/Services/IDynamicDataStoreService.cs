using System.Collections.Generic;
using System.Linq;
using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace DynamicDataStoreManager.Web.AdminTools.DynamicDataStoreManager.Services
{
    public interface IDynamicDataStoreService
    {
        DynamicDataStore GetOrCreateStore<T>() where T : IDynamicData;
        DynamicDataStore GetStore<T>() where T : IDynamicData;
        DynamicDataStore GetStore(string storeName);
        IOrderedQueryable<T> GetItems<T>() where T : IDynamicData;
        void DeleteItem<T>(T item) where T : IDynamicData;
        void DeleteAll<T>() where T : IDynamicData;
        bool SaveItem<T>(T item) where T : IDynamicData;
        Identity SaveItemGetId<T>(T item) where T : IDynamicData;
        void RemapStore<T>();
        void DeleteStore<T>(bool deleteObjects) where T : IDynamicData;
        void DeleteItem(Identity id, string storeName);
        IEnumerable<StoreDefinition> GetAllStoresNamesAndMappings();
    }
}
