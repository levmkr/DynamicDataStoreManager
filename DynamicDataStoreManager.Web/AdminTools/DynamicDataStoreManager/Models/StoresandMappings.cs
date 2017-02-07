using System.Collections.Generic;

namespace DynamicDataStoreManager.Web.AdminTools.DynamicDataStoreManager.Models
{
    public class StoresandMappings
    {
        public StoresandMappings()
        {
            Mappings = new List<string> { "Id" };
        }

        public string Name { get; set; }
        public List<string> Mappings { get; private set; }
    }
}