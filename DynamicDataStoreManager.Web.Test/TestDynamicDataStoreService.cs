using DynamicDataStoreManager.Web.AdminTools.DynamicDataStoreManager.Services;
using EPiServer.Data.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DynamicDataStoreManager.Web.Test
{
    [TestClass]
    public class TestDynamicDataStoreService
    {
        private Mock<IDynamicDataStoreService> _mockService;

        [TestInitialize]
        public void MockDependencies()
        {
            _mockService = new Mock<IDynamicDataStoreService>();

            var mockStore = new Mock<DynamicDataStore>(null);
            mockStore.Setup(s => s.Name).Returns("ExistingStore");

            _mockService.Setup(s => s.GetStore("NonExistantStore")).Returns(() => null);
            _mockService.Setup(s => s.GetStore("ExistingStore")).Returns(mockStore.Object);
        }

        [TestMethod]
        public void Test_GetStore_null()
        {
            var store = _mockService.Object.GetStore("NonExistantStore");
            Assert.IsNull(store);
        }


        [TestMethod]
        public void Test_GetStore_Name()
        {
            var store = _mockService.Object.GetStore("ExistingStore");
            Assert.IsNotNull(store);
            Assert.AreEqual("ExistingStore", store.Name);
        }
    }
}
