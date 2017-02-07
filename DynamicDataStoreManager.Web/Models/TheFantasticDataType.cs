using System.Collections.Generic;
using EPiServer.Data;
using EPiServer.Data.Dynamic;

namespace DynamicDataStoreManager.Web.Models
{
    [EPiServerDataStore(AutomaticallyRemapStore = true)]
    public class TheFantasticDataType : IDynamicData
    {
        public Identity Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public bool IsTrue { get; set; }
        public IEnumerable<string> Items { get; set; }
    }
}