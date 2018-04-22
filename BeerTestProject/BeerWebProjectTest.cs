using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerWebApplication.Controllers;
using System.Web.Mvc;
using BeerWebApplication.Class;
using Newtonsoft.Json;

namespace BeerTestProject
{
    [TestClass]
    public class BeerWebProjectTest
    {
        [TestMethod]
        public void TestController()
        {
            Assert.AreEqual("IndexController", "IndexController");
        }
        [TestMethod]
        public void CheckViewName()
        {
            IndexController ic = new IndexController();
            var result = ic.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void FetchDataAll()
        {
            SearchGrid search = new SearchGrid();
            search.sord = "asc";
            search.sidx = "name";
            search.page = 1;
            IndexController controller = new IndexController();

            JsonResult beerJsonResult = controller.FetchData(search) as JsonResult;
            Assert.IsNotNull(beerJsonResult.Data, "JsonResult returned from action method.");
        }
        [TestMethod]
        public void CalculatePageSize ()
        {
            SearchGrid search = new SearchGrid();
            search.sord = "asc";
            search.sidx = "name";
            search.page = 1;
            IndexController controller = new IndexController();

            JsonResult beerJsonResult = controller.FetchData(search) as JsonResult;
            var json = JsonConvert.SerializeObject(beerJsonResult.Data);
            var recordList = JsonConvert.DeserializeObject<JqGridFormat>(json);
            Assert.AreEqual(50, recordList.rows.Count );
        }

        [TestMethod]
        public void CalculatePageNumber()
        {
            SearchGrid search = new SearchGrid();
            search.sord = "asc";
            search.sidx = "name";
            search.page = 1;
            IndexController controller = new IndexController();

            JsonResult beerJsonResult = controller.FetchData(search) as JsonResult;
            var json = JsonConvert.SerializeObject(beerJsonResult.Data);
            var recordList = JsonConvert.DeserializeObject<JqGridFormat>(json);
            Assert.AreEqual(1, recordList.page);
        }
    }
}
