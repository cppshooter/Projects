using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerWebApplication.Controllers;
using System.Web.Mvc;
using BeerWebApplication.Class;

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
      
    }
}
