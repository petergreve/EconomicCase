using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using econ;
using econ.Data;
using econ.Tests.TesterHelpers;
using econ.Controllers;

namespace econ.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(new TestRepository());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(new TestRepository());

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
